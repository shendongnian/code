            string input = "";
            int numbersEntered = 0;
            int average = 0;
            int total = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter a number or Q to quit", input);
                input = Console.ReadLine();
                int valueEntered;
                if (int.TryParse(input, out valueEntered))
                {
                    total += valueEntered;
                    average = (total / ++numbersEntered);
                    Console.WriteLine("Total: {0}\t Numbers Entered: {1}\t Average: {2}\t", total, numbersEntered, average);
                    Console.ReadKey();
                }
            }
            while (input.ToUpper() != "Q");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
