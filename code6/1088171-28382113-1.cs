    int[,] arr = new int[,]
    {
        {1,2,3 },
        {3,2,1 },
        {2,3,1 }
    };
    List<int> sums = new List<int>();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
         int sum = 0;
         for (int j = 0; j < arr.GetLength(1); j++)
         {
             sum += arr[i, j];      
         }
         sums.Add(sum);
    }
    bool sameResults = sums.Distinct().Count() == 1;
