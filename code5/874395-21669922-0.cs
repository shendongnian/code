    Console.WriteLine("N1: ");
    int N1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("N2: ");
    int N2 = Convert.ToInt32(Console.ReadLine());
    int sum = 0;
    for (int X = N1; X <= N2; X++)
    {
        if (X % 5 != 0)
        {
            sum += X;
        }
    }
    Console.WriteLine("Sum: {0}", sum.ToString());
    Console.ReadLine();
