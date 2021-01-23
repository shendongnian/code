    Console.WriteLine("Please Enter First Name");   
    string firstName = Console.ReadLine();
    
    while(!Regex.IsMatch(firstName, @"^[a-zA-Z]+$"))
    {
        Console.WriteLine("Invalid Name");
        firstName = Console.ReadLine();
    }
    Console.WriteLine("Welcome {0}", firstName);
     
