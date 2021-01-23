    public double[,] GetAveragesOfThirdDimension(double[,,] input)
    {
        double[,] averages = new double[input.GetLength(0), input.GetLength(1)];
        for (int i = 0; i < input.GetLength(0); i++)
        {
            for (int j = 0; j < input.GetLength(1); j++)
            {
                for (int k = 0; k < input.GetLength(2); k++)
                {
                    averages[i,j] = averages[i,j] + input[i,j,k];
                }
                averages[i,j] = averages[i,j] / input.GetLength(2);
            }
        }
        return averages;
    }
