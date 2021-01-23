            Random rnd = new Random();
            int sum=0;
            Console.WriteLine("\n20 random integers from 1 to 10:");
            for (int X = 1; X <= 20; X++)
            {
                int y = rnd.Next(1, 10);
                if (y % 2 == 1)
                sum+=y;                
                
                Console.WriteLine("{0}", y);
            }
            Console.ReadLine("sum is ="+sum);
            Console.ReadLine();
