        Console.WriteLine("This program accepts 5 integers from the user and returns their sum.\nIf an invalid integer is entered, the program notifies the user and asks for correct input.");
        int integerSum = 0;
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Please enter Integer {0} now.", (i + 1));
            string rawInput = Console.ReadLine();
            int integerInput;
            bool isInteger = int.TryParse(rawInput, out integerInput);
            if (isInteger == false)
            {
                Console.WriteLine("This is not a valid integer. Please enter a valid integer now:");
                i--;                
                continue;
            }
            else
            {                   
                integerSum += integerInput;                   
            }
        }
        Console.WriteLine("Result: " + integerSum);
