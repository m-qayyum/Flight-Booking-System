/* In this Program we are making a prototype of booking and canceling flights.
 * 
 * Variable Names:
 * passanger (As a string, to define a range of inputs/bookings which is defined as 10 i.e. you can only do 10 valid enteries 0-9.)
 * Command (As a character, prompt the user to enter a command. Used for while and switch. It's like a condition statement thing also.)
 */


using System;

public static class FBS
{
    // Main Method.
    public static void Main()
    {
        // Defining Different Variables which we are gonna use in Program.
        string[] Passenger = new string[10];
        char Command = ' ';

        // Welcome Message.
        Console.WriteLine("\t\t\t\t\t\tWelcome!");

        // Giving user a set of valid passenger types types so he can avoid making mistakes and if he does next time he will be aware of it.
        Console.WriteLine("\nValid Passenger Types: \n B/b = Booking \n C/c = Cancelation \n P/p = Print \n Q/q = Quit");

        // While loop to run the progrm until user inputs "Q/q".
        while (Command != 'Q')
        {
            // Do While Loop to keep track of passenger type user is entering.
            do
            {
                // Prompt the user.
                Console.Write("\nEnter a valid passenger type: ");
                Command = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                // I f statement to put a condition that is the user inputs the passenger type other than "B/b, C/c, P/p, Q/q", program will show error message of "Invalid input".
                if (Command != 'B' && Command != 'C' && Command != 'P' && Command != 'Q')
                {
                    Console.WriteLine("\t\t\t\tError!!!");

                }

                // Switch statement to choose an appropriate Passenger type.
                switch (Command)
                {
                    // Bookings
                    case 'B':
                        Booking(Passenger);
                        break;

                    // Cancelations
                    case 'C':
                        Cancel(Passenger);
                        break;

                    // Print
                    case 'P':
                        PrintSeat(Passenger);
                        break;

                    //Quit with good bye message
                    case 'Q':
                        Console.WriteLine("\t\t\t\tTake Care & Have a Nice Day.");
                        break;


                    // Error
                    default:
                        // Error Message for user.
                        Console.WriteLine("\t\t\t\tInvalid Input\n\t\t\t\tTry Again...");
                        break;
                }

            } while (Command != 'Q' && Command != 'B' && Command != 'P' && Command != 'C');
        }
        Console.Read();
    }

    // Defined Method # 1 (Finding Empty Seat) which gives the first available seat.
    public static int FindEmptySeat(string[] SeatAssign)
    {
        int result = -1;
        for (int Seat_Number = 0; Seat_Number < SeatAssign.Length; Seat_Number++)
        {
            if (string.IsNullOrEmpty(SeatAssign[Seat_Number]))
            {
                result = Seat_Number;
                Seat_Number = SeatAssign.Length;
            }
        }
        return result;
    }

    // Defined Method # 2 (Find Customer Seat).
    public static int FindCustomerSeat(string[] SeatAssign, string Passenger_Name)
    {
        int result = -1;
        for (int Seat_Number = 0; Seat_Number < SeatAssign.Length; Seat_Number++)
        {
            if (Passenger_Name == SeatAssign[Seat_Number])
                result = Seat_Number;

        }
        return result;
    }

    // Defined Method # 3 (Booking Seats).
    public static void Booking(string[] SeatAssign)
    {
        int Seat_Number = FindEmptySeat(SeatAssign);

        do
        {
            Console.Write("Enter Passangers' name: ");
            SeatAssign[Seat_Number] = Console.ReadLine();
        } while (SeatAssign[Seat_Number] == "");
    }

    // Defined Method # 4 (Cancelling Seats).
    public static void Cancel(string[] seatAssign)
    {
        string Passenger_Name;
        int Seat_Number;
        do
        {
            Console.Write("Enter Passangers' name: ");
            Passenger_Name = Console.ReadLine();
        } while (string.IsNullOrEmpty(Passenger_Name));
        Seat_Number = FindCustomerSeat(seatAssign, Passenger_Name);
        if (Seat_Number == -1)
        {
            Console.WriteLine("\nDear Customer!\nThere are no seats booked with the name {0}.\nSorry for the inconvenience.", Passenger_Name);
        }
        else
        {
            seatAssign[Seat_Number] = null;
        }

    }

    // Defined Method # 5 (Printing Seats).
    public static void PrintSeat(string[] SeatAssign)
    {
        for (int Seat_Number = 0; Seat_Number < SeatAssign.Length; Seat_Number++)
        {
            Console.WriteLine("Customer Name: {0} \t Seat Number:{1}", SeatAssign[Seat_Number], Seat_Number);

        }
    }
}