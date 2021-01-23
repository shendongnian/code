    do 
    {
        Console.WriteLine("hello {0} what would you like me to do", UserName);
        if (line == "Time") Console.WriteLine("its {1}", UserName, System.DateTime.Now.TimeOfDay);
        if (line == "Date") Console.WriteLine(System.DateTime.Today);
        
        Console.WriteLine("anything else");
    }
    while (string.Equals(Console.ReadLine(), "yes", StringComparison.InvariantCultureIgnoreCase));
    
