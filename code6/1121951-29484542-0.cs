    public double[,] Transpose(double[,] matrix)
    {
        int w = matrix.GetLength(0);
        int h = matrix.GetLength(1);
        double[,] result = new double[h, w];
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                result[j, i] = matrix[i, j];
            }
        }
        return result;
    }
