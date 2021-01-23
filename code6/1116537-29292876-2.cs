    int[][] a = { new int[] { 1, 2, 3, 4 }, new int[] { 3, 9, 9 } };
    int[] b = new int[] { 5, 6, 1, 2, 7, 8 };
    int Count = 0;
    k = 0;
    for (int i = 0; i < a.Length; i++)
    {
        for (int j = 0; j < a[i].Length; j++)
        {
            if (b[k] == a[i][j])
            {
                Count++;
            }
            k++;
        }
    }
    Console.WriteLine(Count);
    Console.ReadLine();
