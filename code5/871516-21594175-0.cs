            Console.WriteLine("\n5 random integers from -100 to 100:");
            for (int X = 1; X <= 5; X++)
            {
                int Y = rnd.Next(-100, 100);
                if (Y > 0)
                {
                     Console.WriteLine("These are the positive numbers: {0}", Y);
                }
                else
                {
                    Console.WriteLine("These are the negative numbers: {0}", Y);
                }
            }
