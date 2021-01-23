            int max = 0;
            while (purchase != QUIT || max < 5)
            {
                total += purchase;
                Console.Write("Enter another purchase amount or " + QUIT + " to calculate >> "); //I only want this to appear 4 more times\\
                inputString = Console.ReadLine();
                purchase = Convert.ToDouble(inputString);
                max++;
            }
            Console.WriteLine("Your total is {0}", total.ToString("C"));
