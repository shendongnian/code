    int[,] a = new int[10,10];
    int l0 = a.GetLength(0);
    int l1 = a.GetLength(1);
    var b = new List<List<int>>(
                   Enumerable.Range(0, l0)
                             .Select(p => new List<int>(
                                              Enumerable.Range(0, l1)
                                                        .Select(q => a[p, q]))));
    
    var c = new int[b.Count, b[0].Count];
    
    for (int i = 0; i < b.Count; i++)
    {
        for (int j = 0; j < b[i].Count; j++)
        {
            c[i, j] = b[i][j];
        }
    }
