                    if (inputString == Pizza.Name)
                    {
                        Pizza.PrintFoodProfile();
                        totalCost = totalCost + Pizza.Cost;
                        Console.WriteLine("The total cost is: £" + totalCost);
                        Console.WriteLine();
                    }
					else if (inputString == Burger.Name)
                    {
                        Burger.PrintFoodProfile();
                        totalCost = totalCost + Burger.Cost;
                        Console.WriteLine("The total cost is: £" + totalCost);
                        Console.WriteLine();
                    }
