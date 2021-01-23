        Console.WriteLine("how fast would you like the sounds to play?");
        Console.WriteLine("70 = fast and 300 = slow can pick any number inbetween");
        string choice = Console.ReadLine();
        int speed = Convert.ToInt32(choice);
        Console.WriteLine(speed);
        Console.WriteLine("how many times should i beep?");
        string choice2 = Console.ReadLine();
        int j = Convert.ToInt32(choice2);
        Console.Write(j);
        for (int i = 0; i < j; i++)
        {
            Console.Beep(1000, speed);
        }
