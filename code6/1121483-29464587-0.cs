            Console.WriteLine("How many times would you like to roll?");
            string strCount = Console.ReadLine();
            int n = Convert.ToInt32(strCount);
            Random die = new Random();
            for (int i = 1;  i <= n;  i++)
            {
                int roll = die.Next(1, 6);
                Console.WriteLine("Die {0} landed on {1}.", i, roll);
            }
            
            Console.ReadLine();
