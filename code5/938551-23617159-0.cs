        int pin = 1234;
        int guess = 0;
        int count;
        for (count = 2; count > -1; count-- )
        {
            Console.WriteLine("Enter a 4 digit pin number");
            guess = int.Parse(Console.ReadLine());
            if(guess != pin)
            {
                 Console.WriteLine("");
                 Console.WriteLine("You entered an incorrect pin number, you have {0}   attempts remaining", count);
            }
            else
            {
               Console.WriteLine("You have entered the correct pin number");
               break;
            }
        }
        Console.WriteLine("");
        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
