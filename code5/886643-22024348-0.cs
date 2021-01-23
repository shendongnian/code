            string input = "";
            double noentered = 0;
            double total = 0;
            double average = 0;
            do
            {
                {
                    Console.Write("enter a number or Q to quit", input);
                    input = Console.ReadLine();
                    if (input != "q" && input != "Q")
                    {
                        total += Convert.ToInt32(input);
                        average = total / noentered;
                        noentered++;
                        Console.WriteLine(" Total: {0} \t Number Entered: {1} \t Average:{2}", total, noentered, average);
                    }
                }
            } while (input != "q" && input != "Q");
