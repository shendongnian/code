    public List<int> ProduceRandom100NumbersWithAverageOfSeven()
    {
        var rand = new Random();
        var seed = rand.Next();
        if(seed > 0.5)
        {
            return new List(Enumerable.Concat(
                     Enumerable.Repeat(6, 50),
                     Enumerable.Repeat(8, 50)));
        }
        else
        {
            return new List(Enumerable.Concat(
                     Enumerable.Repeat(8, 50),
                     Enumerable.Repeat(6, 50)));
        }
    }
