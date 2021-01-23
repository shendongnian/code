    public static void ReadNewCustomerFromConsole()
    {
        var pathToYourFile = @"..\..\..\Files\Customer.txt";
     
        using (var writer = new StreamWriter(pathToYourFile , true))
        {
            Console.Clear();
    
            // Write a message in Console
            Console.WriteLine("Enter Customer Number: ");
    
            // Read user input from Console
            var customerNumber = Console.ReadLine();
    
            // Write user input to file
            writer.WriteLine(customerNumber);
    
            // Now read Customer Surname
            Console.WriteLine("Enter Customer Surname:");
            var customerSurname = Console.ReadLine();
            writer.WriteLine(customerSurname);
            // And so on for the other data you need ...
        }
    }
        
