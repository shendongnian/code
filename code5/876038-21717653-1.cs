                if (ichoice == 3)
                {
                    Console.WriteLine("Thank you for using the temperature conversion application. Please come again.");
                break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again!");
                    int.TryParse(Console.ReadKey().ToString(), out ichoice );
                }
