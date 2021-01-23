           static void Main(string[] args)
            {
                String [] lines= File.ReadAllLines(@"C:\score.txt");
                long max = 0;
                long score=0;
                foreach (String line in lines)
                {
                    if (Int64.TryParse(line, out score))
                    {
                    if (score > max)
                        max = score;
                    }
                }
                Console.WriteLine("Maximum Score is "+max);
            }
