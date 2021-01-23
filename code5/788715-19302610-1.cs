    String name = String.Empty;
    if (ch == 0)
    {
        Console.WriteLine("What is your name?");
        name = Console.ReadLine();
        Console.WriteLine("Thank you!");
        Console.ReadKey();
    }
    else
    {
        name = Settings.Default.name;
    }
    Console.WriteLine("Your name is " + name);
