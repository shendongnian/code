    Random r = new Random();
                //int[,] mas = new int[4, 5];
    
                int[][] mas = new int[4][];
                
    
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = new int[5];
    
                    for (int j = 0; j < mas[i].Length; j++)
                    {
                        mas[i][j] = r.Next(1, 10);
                        Console.Write("{0}\t", mas[i][j]);
                    }
    
                    Console.WriteLine();
                }
    
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = mas[i].Select((c, ind) =>
                    {
                        if (ind > i)
                            c = 0;
    
                        return c;
    
                    }).ToArray();
                }
