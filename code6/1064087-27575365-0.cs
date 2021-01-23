    int[] array = new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    int rows = 3;
    int cols = 3;
    int count = 0;
    for (int x = 1; x <= rows; x++)
    {
        int startingPos = array.Length - (x * rows);
        for (int y = cols; y > 0; y--)
        {
            Console.Write(array[startingPos] +", ");
            count++;
            startingPos++;
        }
        Console.WriteLine();
    }
