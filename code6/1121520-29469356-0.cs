    int columnTotal, average;
    for (int col = 0; col < 3; col++)
    {
        columnTotal = 0;
        for (int row = 0; row < 2; col++)
        {
            columnTotal += grades[row, col];
        }
        average = columnTotal/2;
        Console.WriteLine("Average: {0}", average);
    }
