    public ShuffleDeck()
        : this(new Random(DateTime.Now.Millisecond))
    {
    }
    public ShuffleDeck(Random randomizer)
    {
        this.Randomizer = randomizer;
    }
