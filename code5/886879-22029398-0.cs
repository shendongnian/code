        do
        {
            Console.WriteLine("Enter a number of Q to quit", input);
            input = Console.ReadLine();
            int val;
            if (int.TryParse(input, out val))
            {
                total += val;
                average = (total / numbersEntered);
                Console.WriteLine("Total: {0}\t Numbers Entered: {1}\t Average: {2}\t", total, numbersEntered++, average);
            }
        }
        while (input.ToUpper() != "Q");
