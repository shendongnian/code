    private readonly decimal amount;
    public bool Equals(Volume other)
    {
        return amount == other.amount;
    }
    public override bool Equals(object obj)
    {
        return obj is Volume ? Equals((Volume)obj) : base.Equals(obj);
    }
    public override int GetHashCode()
    {
        return amount.GetHashCode();
    }
