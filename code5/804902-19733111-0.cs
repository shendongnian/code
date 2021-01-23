    String sName;
    Console.Write("Enter a name (or XXX to end): ");
    sName = Console.ReadLine();
    while (sName != "XXX")
    {
       Console.Write("The Name is: " + sName);
       Console.WriteLine();
       Console.Write("Enter a name (or XXX to end): ");
       sName = Console.ReadLine();
    }
