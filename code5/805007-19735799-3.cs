            double[] X = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0 };
            var lbound = X.GetLowerBound(0);
            var ubound = X.GetUpperBound(0);
            double[] newArray = X.Concat(Enumerable.Repeat(0.0, ubound)).ToArray();
           double[,] Y = new double[X.Length, X.Length];
    for (int targetRow = 0; targetRow <= ubound; targetRow++)
    {
        Buffer.BlockCopy
        (
            newArray,                                      // 1D source array
            (targetRow * sizeof(double)),                  // source array offset
            Y,                                             // 2D target (destination) array
            ((targetRow * X.Length) * sizeof(double)),     // target array offset
            X.Length  * sizeof(double)                     // count
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
