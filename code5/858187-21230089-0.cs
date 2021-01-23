    Console.WriteLine("Please Enter First Name");
    bool isNotName = true;
    string firstName = Console.ReadLine();
    
    while (isNotName)
    {
        if (Regex.IsMatch(firstName, @"^[a-zA-Z]+$"))
        {            
            Console.WriteLine("Welcome {0}", firstName);            
            isNotName = false;
        }    
        else
        {
            Console.WriteLine("Invalid Name");
            firstName = Console.ReadLine(); // <---- re-assign name here
        }
    }
