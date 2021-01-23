    for (int i = 0; i < aTable.IntColumns; i++)
    {
        for (int j = 0; j < aTable.IntRows; j++)
        {
            if (j != 0)
                Console.Write(", ");
            Console.Write(array[i, j]);
        }
        Console.WriteLine();
    }
