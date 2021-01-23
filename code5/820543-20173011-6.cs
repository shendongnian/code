    void Main()
    {
        const int amount_to_deal = 5;
        var arrayBlessings = new List<int>{1, 2, 3, 4, 5, 6};
        var arrayGameBlessings = new List<int>();
        var rnd = new Random();
        for (int i = 0; i < amount_to_deal; i++)
        {
            int bless = rnd.Next(arrayBlessings.Count);
            arrayGameBlessings.Add(arrayBlessings[bless]);
            arrayBlessings.RemoveAt(bless);
        }
        Console.WriteLine(arrayBlessings);
        Console.WriteLine(arrayGameBlessings);
    }
