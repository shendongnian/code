    public Decimal Price { get; set; } // shorthanded here for brevity
    public void MarkupThePrice(Decimal Percent)
    {
        Price *= (1 + Percent);
    }
