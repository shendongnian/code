    int[,] binaryResult = new int[list.Count(), list.First().Count()];
    
    for (int i = 0; i < binaryResult.GetLength(0); i++)
        for (int j = 0; j < binaryResult.GetLength(1); j++)
            binaryResult[i, j] = list.ElementAt(i).ElementAt(j);
