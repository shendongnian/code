    string decision = "y";
    while (decision == "y")
    {
        string name;
        Console.Write("Input name: ");
        name = Console.ReadLine();
        Console.WriteLine("Name is " + name);
        Console.Write("\nWould you like to input another name? y/n: ");
        decision = Console.ReadLine().ToLower();
    }
    
