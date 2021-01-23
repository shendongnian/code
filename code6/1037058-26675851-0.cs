            var test = Console.ReadLine().Trim();
            long t;
            if (Int64.TryParse(test, out t))
            {
                while (t > 0)
                {
                    t--;
                    var res = Console.ReadLine().Trim();
                    var n = Int64.Parse(res);
                    Console.WriteLine(n);
                    var ans = n*8;
                    if (n > 1)
                    {
                        ans = ans + (n - 1)*6;
                    }
                    Console.WriteLine(ans);
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid argument {0} entered.", test);
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
