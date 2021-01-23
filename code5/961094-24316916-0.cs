    private static void Economy(ref bool[] seats)
    {
        for (int i = 5; i < 10; i++)
        {   // <---- Added the brackets
            if (seats[i] == false)
            {
                seats[i] = true;
                break;  // <----- You forgot to break when you reserved a seat.
            }
            else if (i == 9)  // <---- You weren't checking if all seats are taken.
            {
                Console.WriteLine("Economy class is full. Would you like to fly First Class");
                if (Console.ReadLine().ToLower() == "y")
                    FirstClass(ref seats);
                else
                    Console.WriteLine("The next flight is in three hours!. Good Bye");
            }
         }
    }
