    public ValuationPrice this[string name]
    {
        get
        {
            return this.First(n => n.Name == value);
        }
    }
