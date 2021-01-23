    int[] dice = new int[2];
    int sum = 0;
    for (int i = 1; i <= 100; i++)
    {
        dice[0] = x.Next(1, 7);
        dice[1] = x.Next(1, 7);
        sum += dice[0] + dice[1];
        ...
    }
    Console.WriteLine("Total sum: " + sum);
