    public Decimal Price { get; set; } // shorthanded here for brevity
    public Decimal GetMarkedUpPrice(Decimal Percent)
    {
        return Price *= 1 + Percent;
    }
