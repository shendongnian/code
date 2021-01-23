            int amount = 0;
            string input = Console.ReadLine();
            char[] chars = input.ToArray();
            foreach (char c in chars)
            {
                amount++; 
            }
            Console.WriteLine(amount.ToString());
            Console.ReadKey();
