        Random r = new Random();
        int[,] mas = new int[4, 5];
        for (int i = 0; i < mas.GetLength(0); i++)
        {
            for (int j = 0; j < mas.GetLength(1); j++)
            {
                mas[i, j] = j > i ? 0 : r.Next(1, 10);
                Console.Write("{0}\t", mas[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
