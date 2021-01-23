     for (int targetRow = 0; targetRow <= ubound; targetRow++)
      {
        Buffer.BlockCopy
        (
            X,                                        // 1D source array
            targetRow * sizeof(double),               // source array offset
            Y,                                        // 2D target (destination) array
            (targetRow * X.Length) * sizeof(double),  // target array offset
            (Y.GetUpperBound(1) + 1 - targetRow) * sizeof(double)  // count
        );
    }
    for (var i = 0; i <= ubound; i++)
    {
        for (var j = 0; j <= ubound; j++)
        {
            Console.Write(Y[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.ReadKey();
