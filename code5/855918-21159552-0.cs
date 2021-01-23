            int temp,zipCode;
            bool breakLoop = false;
                 
            Console.WriteLine("Enter the the zip code of the contact.");
            while (breakLoop == false)
            {
                string userInput = Console.ReadLine();
                if (userInput.Length != 5)
                {
                    Console.WriteLine("Error. Zip code is not 5 digits. Please enter a valid number.");
                    continue;
                }
                int.TryParse(userInput, out temp);
                if (temp == 0)
                {
                    Console.WriteLine("Error. Please enter a valid number.");
                    continue;
                }                
                
                zipCode = temp;
                breakLoop = true;
                break;
            }
