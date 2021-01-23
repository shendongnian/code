    Console.WriteLine("Please Enter First Name");
    string firstName = Console.ReadLine();
    While (!Regex.IsMatch(firstName, @"^[a-zA-Z'-]+$")) {
        Console.WriteLine("Invalid Name");
        firstName = Console.ReadLine();
    }
    Console.WriteLine("Welcome {0}", firstName);
