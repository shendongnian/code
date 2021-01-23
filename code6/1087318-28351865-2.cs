    foreach (string test in questionDict.Keys)
    {
        Console.WriteLine("{0}", test);
        string userInput = Console.ReadLine();
        if (userInput == "yes")
        {
            Console.WriteLine("{0}", test);
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("AW NAW");
            Console.ReadLine();
        }
    }
