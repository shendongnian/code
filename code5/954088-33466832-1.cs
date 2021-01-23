    int[,] matrix = new int[2, 2] { {2, 2}, {1, 1} };
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int k = 0; k < matrix.GetLength(1); k++ )
        {
            //put a single value
            Console.Write(matrix[i,k]);
        }
        //next row
        Console.WriteLine();
    }
