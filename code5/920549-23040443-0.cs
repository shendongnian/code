    for (int i = 3; i <= 1000; i++)
    {
        if (i % 3 == 0 || i % 5 == 0)
        {
            Console.WriteLine(i);
        }
        if (i % 100 == 0) Console.Read();
    }
