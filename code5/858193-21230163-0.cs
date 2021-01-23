    string firstName;
    while (!(Regex.IsMatch(firstName = Console.ReadLine(), @"^[a-zA-Z]+$")))
    {
        Console.WriteLine("Invalid Name"); 
    }
                        
    Console.WriteLine("Welcome {0}", firstName);
