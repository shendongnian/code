                Console.WriteLine("Enter the the zip code of the contact.");
                var temp = Console.ReadLine();
                string zipcode = string.Empty;
                while (temp.Length != 5)
                {
                    Console.WriteLine("Error. Zip code is not 5 digits. Please enter a valid number.");
                    if (temp.Length == 5)
                    {
                        zipcode = temp;
                        break;
                    }
                    else
                    {
                        temp = Console.ReadLine();
                    }
                }
                Console.Write(zipcode);
