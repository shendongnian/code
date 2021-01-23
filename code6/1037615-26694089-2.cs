    void CopydArrayScaled(int[,] g, int[,] n)
    {
        int gRowSkip = g.GetLength(0) - n.GetLength(0);
        for (int nRowIdx = 0, gRowIdx = 0; nRowIdx < n.GetLength(0); nRowIdx++)
        {
            int gColSkip = g.GetLength(1) - n.GetLength(1);
            for (int nColIdx = 0, gColIdx = 0; nColIdx < n.GetLength(1); nColIdx++)
            {
                n[nRowIdx, nColIdx] = g[gRowIdx, gColIdx];
                if (gColSkip > 0)
                {
                    gColSkip--;
                    gColIdx += 2;
                }
                else if (gColSkip < 0)
                {
                    if (nColIdx % 2 == 1)
                    {
                        gColIdx++;
                        gColSkip++;
                    }
                }
                else
                {
                    gColIdx++;
                }
            }
            if (gRowSkip > 0)
            {
                gRowSkip--;
                gRowIdx += 2;
            }
            else if (gRowSkip < 0)
            {
                if (nRowIdx % 2 == 1)
                {
                    gRowIdx++;
                    gRowSkip++;
                }
            }
            else
            {
                gRowIdx++;
            }
        }
    }
    void CopydArrayScaled2(int[,] g, int[,] n)
    {
        int gRowSkip = g.GetLength(0) - n.GetLength(0);
        for (int nRowIdx = 0; nRowIdx < n.GetLength(0); nRowIdx++)
        {
            int gRowIdx = nRowIdx * g.GetLength(0) / n.GetLength(0);
            int gColSkip = g.GetLength(1) - n.GetLength(1);
            for (int nColIdx = 0; nColIdx < n.GetLength(1); nColIdx++)
            {
                int gColIdx = nColIdx * g.GetLength(1) / n.GetLength(1);
                n[nRowIdx, nColIdx] = g[gRowIdx, gColIdx];
            }
        }
    }
    
    void PrintArray(int[,] a)
    {
        Console.WriteLine("Destination dimensions: [{0},{1}]", a.GetLength(0), a.GetLength(1));
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                if (j != 0) Console.Write(",");
                Console.Write(a[i, j]);
            }
            Console.WriteLine();
        }
    }
    
    void Test()
    {
        int[,] g = new int[4, 4] { { 0, 1, 2, 3 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 } };
    
        int[,] n = new int[2, 2];
        CopydArrayScaled(g, n);
        PrintArray(n);
    
        int [,] n2 = new int[8, 8];
        CopydArrayScaled(g, n2);
        PrintArray(n2);
    
        int[,] n3 = new int[4, 4];
        CopydArrayScaled(g, n3);
        PrintArray(n3);
    }
