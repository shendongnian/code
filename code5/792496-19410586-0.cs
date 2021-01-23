    for (int i = 0; i < aTable.IntColumns; i++)
    {
        for (int j = 0; j < aTable.IntRows; j++)
        {
            Console.Write(array[i, j]);
            if (j != aTable.IntRows - 1)
                Console.Write(", ");
        }
        Console.WriteLine();
    }
