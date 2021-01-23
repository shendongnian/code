     int integerSum = 0;
            for (int i = 0; i < 5;)
            {
                Console.WriteLine("Please enter Integer {0} now.", (i + 1));
                string rawInput = Console.ReadLine();
                int integerInput;
                bool isInteger = int.TryParse(rawInput, out integerInput);
                if (isInteger == false)
                {
                    Console.WriteLine("This is not a valid integer. Please enter a valid integer now:");
                    
                }
                else if (isInteger == true)
                {
                    integerSum += integerInput;
                    i++;
                }
                
            }
            Console.WriteLine("The sum of all number entered is:{1}{0} ", integerSum, Environment.NewLine);
