        Console.WriteLine("Enter the the zip code of the contact.");
         var temp = int.Parse(Console.ReadLine());
            while (temp.ToString().Length != 5)
            {
                Console.WriteLine("Error. Zip code is not 5 digits. Please enter a valid number.");
                temp = int.Parse(Console.ReadLine());
                if (temp.ToString().Length == 5)
                {
                    temp = int.Parse(Console.ReadLine());
                    
                }
            }
