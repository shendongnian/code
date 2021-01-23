    for (int x = 0; x < m.GetLength(0); x++)
    {
        for (int y = 0; y < m.GetLength(1); y++)
        {
             for (int z = 0; z < m.GetLength(2); z++)
             {
                  Console.Write("{0} ", m[x, y, z]);
             }
             Console.WriteLine();
        }
        Console.WriteLine();
     }
