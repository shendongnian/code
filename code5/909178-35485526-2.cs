                long n = long.Parse(Console.ReadLine());
                bool result = false;
                
                if ((n % 1000) / 100 == 5)
                {
                    result = true;
                }
                Console.WriteLine(result);
                
