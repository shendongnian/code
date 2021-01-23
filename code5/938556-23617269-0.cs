    int pin = 1234;
    int guess = 0;
    int count = 3;
    
    while (guess != pin && count > 0)
    {
        Console.Write("Enter a 4 digit pin number: ");
        int.TryParse(Console.ReadLine(), out guess);
        if (guess != pin)
        {
            Console.WriteLine("");
            Console.WriteLine("You entered an incorrect pin number, you have {0}   attempts remaining", count - 1);
        }
        else
        {
            Console.WriteLine("You have entered the correct pin number");
        }
        count--;
    }
    Console.ReadLine();
