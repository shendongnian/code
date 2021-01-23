    int sum = 0;
    for (int X = 1; X <= 20; X++)
    {
        int y = rnd.Next(1, 10);
        if (y % 2 == 1)
        {
            sum += y; // sum = sum + y;
        }
        Console.WriteLine("{0}", y);
    }
    
    Console.WriteLine("sum: {0}", sum);
