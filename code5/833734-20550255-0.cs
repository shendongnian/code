           static void Main(string[] args)
            {
                String [] lines= File.ReadAllLines(@"C:\score.txt");
                int max = 0;
                int score=0;
                foreach (String line in lines)
                {
                    if (Int32.TryParse(line, out score))
                    {
                    if (score > max)
                        max = score;
                    }
                }
                Console.WriteLine(max);
            }
