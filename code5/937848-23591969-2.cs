    using (StreamWriter fajl = new StreamWriter(@"..\..\..\keretes.txt"))
    {
        int ciklusok = 0;
    
        for (int y = 0; pixelek > y; y++)
        {
            for (int x = 0; pixelek > x; x++)
            {
                 fajl.WriteLine(kep[x, y]);
                 ciklusok++;
            }
        }
    }
