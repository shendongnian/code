    private static void MultiplyMatricesParallel(double[,] matA, double[,] matB, double[,] result)
    {
        int matACols = matA.GetLength(1);
        int matBCols = matB.GetLength(1);
        int matARows = matA.GetLength(0);
        // A basic matrix multiplication.
        // Parallelize the outer loop to partition the source array by rows.
        Parallel.For(0, matARows*matBCols, ij =>
                                      {
                                          i = ij / matBCols;
                                          j = ij % matBCols;
                                          // Use a temporary to improve parallel performance.
                                          double temp = 0;
                                          for (int k = 0; k < matACols; k++)
                                          {
                                              temp += matA[i, k]*matB[k, j];
                                          }
                                          result[i, j] = temp;
                                          
                                      }); // Parallel.For
    }
