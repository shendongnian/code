            string userInputedValue;
            
            Console.Write("Enter Length: ");
            
            userInputedValue = Console.ReadLine();
            for (int i = 1; i <= Int32.Parse(userInputedValue); i++)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
