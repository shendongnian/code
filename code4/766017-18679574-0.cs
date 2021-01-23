    string name;
    do
    {
         Console.WriteLine("Enter Name");
         name = Console.ReadLine();
    }
    while (string.Equals(name, "ashley", StringComparison.CurrentCultureIgnoreCase));
