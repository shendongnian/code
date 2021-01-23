        int max = 0;
        for (int j = 0; j < SIZE; j++)
        {
            int currentColumn = 0;
            for (int i = 0; i < SIZE; i++)
            {
                currentColumn = currentColumn + Table[i, j];
                if (max < Table[i, j])
                {
                    max = Table[i, j];
                }
            }
            Console.Write();
            Console.Write("\t");
        }
        Console.WriteLine("The maximum value for the table is {0}", max);
