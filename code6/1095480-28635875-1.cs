    string name = "x"; // anything except an empty string
    Console.WriteLine("Enter a blank line to finish...");
    while (!string.IsNullOrWhiteSpace(name))
    {
        Console.Write("\nInput name: ");
        name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name is " + name);
        }
    }
    
