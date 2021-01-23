    using MathNet.Numerics.LinearAlgebra;
    public static double DistanceBetween2Points(double[,] p1, double[,] p2, int patchSize)
    {
       var A = Matrix<double>.Build.DenseOfArray(p1).SubMatrix(0, patchSize, 0, patchSize);
       var B = Matrix<double>.Build.DenseOfArray(p2).SubMatrix(0, patchSize, 0, patchSize);
        
       return (A - B).RowAbsoluteSums().Sum();
    }
