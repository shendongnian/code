    static void Main(string[] args)
                {
                    int[,] S = null;
                    int N = 0;
                    string line; //to hold one line of file
                    string[] token; //to hold each token in line
                    char[] separator = { ',' };
        
        
                    //open file
                    try
                    {
                        using (StreamReader sr = new StreamReader(@"C:\Users\sb9923\Desktop\ms.txt"))
                        {
                            line = sr.ReadLine();
                            token = line.Split(separator);
                            N = token.Count();
                            S = new int[N, N];
                            for (int i = 0; i < N; i++)
                                S[0, i] = Convert.ToInt32(token[i]);
                            for (int r = 1; r < N; r++)
                            {
                                line = sr.ReadLine();
                                token = line.Split(separator);
                                for (int c = 0; c < N; c++)
                                    S[r, c] = Convert.ToInt32(token[c]);
                            }
                            sr.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The file could not be read:");
                        Console.WriteLine(e.Message);
                    }
        
                    int magicValue = GetSum(N * N) / N;
                    
                    //Check for magic
                    bool isMagic = true;
                    for (int counterY = 0; counterY < S.GetLength(1); counterY++)
                    {
                        int rowValue = 0;
                        int columnValue = 0;
                        for (int counterX = 0; counterX < S.GetLength(0); counterX++)
                        {
                            rowValue += Convert.ToInt32(S[counterY, counterX]);
                            columnValue += Convert.ToInt32(S[counterX, counterY]);
                        }
        
                        if (rowValue != magicValue)
                        {
                            isMagic = false;
                            break;
                        }
        
                        if (columnValue != magicValue)
                        {
                            isMagic = false;
                            break;
                        }
        
                        rowValue = 0;
                        columnValue = 0;
                    }
        
                    if (isMagic)
                    {
                        Console.WriteLine("Yeah it is magic! :)");
                    }
                    else
                    {
                        Console.WriteLine("No magic in the air!");
                    }
                }
    private static int GetSum(int maxValue)
            {
                if (maxValue < 1)
                {
                    return 0;
                }
    
                return maxValue + GetSum(maxValue - 1);
        }
