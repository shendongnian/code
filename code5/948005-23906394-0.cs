    int numCols = 3;
    for (int i = 0; i < row.Length; i += numCols)
    {               
        for (int j = i; j < i + numCols && j < row.Length; j++)
        {
            Console.Write(row[j] + "\t");
        }
        Console.WriteLine();
    }
