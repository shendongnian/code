    String sName="";
    while (sName != "XXX")
    {
        Console.Write("Enter a name (or XXX to end): ");
        sName = Console.ReadLine();
        Console.Write("The Name is: " + sName);
        Console.WriteLine();
    }
    Console.WriteLine("You are now past the while loop");
    Console.WriteLine("Press any key to close");
    Console.ReadKey();
