     public new void Print(int x, int z)
            {
                var peakStart = x;
                var peakEnd = x;
    
                for (int i = 0; i < z; i++)
                {
                    for (int j = 0; j < 2 * x + 1; j++)
                    {
                        if (peakStart < 1.5 * x && j >= peakStart && j <= peakEnd)
                            Console.Write("*");
                        else
                            Console.Write(" ");
                    }
                    peakStart--;
                    peakEnd++;
                    Console.WriteLine("");
                }
            }
