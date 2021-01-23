    private decimal price;
    public decimal Price
    {
        get
        {
            { return this.price; }
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The price should be positive!");
            }
            else
            {
                this.price = value;
            }
        }
    }
