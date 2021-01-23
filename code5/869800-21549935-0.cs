    static void Main(string[] args)
    {
        //// A. 2D array of strings.
        string[,] a = new string[100, 4];
    
        int bound0 = a.GetUpperBound(0);
        int bound1 = a.GetUpperBound(1);
        for (int i = 0; i <= bound0; i++)
        {
             for (int x = 0; x <= bound1; x++)
             {
                   string s1 = a[i, x];
                   Console.WriteLine(s1);
             }
        }
        Console.WriteLine();
        Console.ReadKey();
    }
