            Random rnd = new Random();
            Console.WriteLine("N1: ");
            int N1 = 0;
            int total = 0;
            int.TryParse(Console.ReadLine(), out N1);
            Console.WriteLine("N2: ");
            int N2 = 0;
            int.TryParse(Console.ReadLine(), out N2);
            int x1 = 0, x2 = 0;
            if (N1 < N2)
            {
                x1 = N1;
                x2 = N2;
            }
            else
            {
                x1 = N2;
                x2 = N1;
            }
                for (int X = x1; X <= x2; X++)
                {
                    int y = rnd.Next(N1, N2);
                    if (y % 5 == 0)
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        total = total + y;
                        Console.WriteLine("");
                    }
                }
            Console.ReadLine();
