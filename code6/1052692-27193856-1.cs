    inputString = Console.ReadLine();					                   
                        if (inputString == Pizza.Name)
                        {
                            Pizza.PrintFoodProfile();
                            totalCost = totalCost + Pizza.Cost;
                            Console.WriteLine("The total cost is: £" + totalCost);
                            Console.WriteLine();
                        }
