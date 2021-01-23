     static void Main(string[] args)
     {
        char userInput;
        char upper;
        Accounts myAccounts = new Accounts();
        myAccounts.input();
        do
        {
            Console.WriteLine("Enter an A to search account numbers");
            Console.WriteLine("Enter a B to average the accounts");
            Console.WriteLine("Enter X to quit the program");
            Console.WriteLine("Enter an option --->");
            userInput = Convert.ToChar(Console.ReadLine());
            upper = char.ToUpper(userInput);
            if (upper == 'A')
            {
                myAccounts.search();
            }
            else if (upper == 'B')
            {
                myAccounts.average();
                
            }
            else
                Console.WriteLine("You entered an incorrect option, please select new option");
        }   
        while (upper != 'X')     
    }
