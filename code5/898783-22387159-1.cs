    int[,] result = new int[4, 4];
    
    var lines = File.ReadLines(@"C:\Left.txt")
                   .Select(x => x.Split()).ToList();
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            result[i, j] = int.Parse(lines[i][j]);
        }
    }
