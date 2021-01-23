    static public void Print2DArray(int[][] A)
    {
        foreach (int[] row in A)
        {
            foreach (int element in row)
            {
                  Console.Write(element.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
