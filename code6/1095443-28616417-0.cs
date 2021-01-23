    public static void PrintArray(int[,] arrayParam)
    {
        for(int i = 0; i< arrayParam.GetLength(0); i++)
        {
             for(int j = 0; j < arrayParam.GetLength(1); j++)
             {
                   Console.Write(" numbers[{0}{{1}}] = {2} ", i, j, arrayParam[i, j]);
             }
             Console.WritLine();
        }
    }
