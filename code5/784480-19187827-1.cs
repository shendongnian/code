    int[,] numbers = new int[4, 5] { { 1, -2, 6, -9, 8 }, { -3, 4, -3, 6, 7 }, { 5, 6, -9, 0, -2 }, { 4, 5, -1, -7, 1 } };
    //search the array for numbers less than 0. Then print their positions
    for (int r = 0; r < 4; r++)
    {
        for (int c = 0; c < 5; c++)
        {
            if (numbers[r, c] < 0)
            {
                Console.Write(numbers.GetValue(r, c)); // better to use numbers[r,c]
                Console.Write(" Row: " + r);
                Console.WriteLine(" Column: " +c);
            }
        }
        Console.WriteLine(" ");
    }
