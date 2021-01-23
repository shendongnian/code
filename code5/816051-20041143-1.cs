    int Temp = 200;
    var PrimeBuilders = new List<int> {200, 300, 400, 500, 200, 600, 400};
    for (int i = 0; i < PrimeBuilders.Count; i++)
    {
        Console.WriteLine("Current index: " + i);
        if (PrimeBuilders[i] != Temp)
        {
            Console.WriteLine("Match found at index: " + i);
        }
    }
