    static void InitMatrix(int[,] mat)
    {
        Random rnd = new Random();
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            List<int> numbers = Enumerable.Range(1, 45).ToList();
            if(mat.GetLength(0)< mat.GetLength(1))
            {
               for (int j = 0; j < mat.GetLength(1); j++)
               {
                   int index = rnd.Next(0, numbers.Count );
                   mat[i, j] = numbers[index];
                   numbers.RemoveAt(index);
               }
            }
        }
    }
