    private Dictionary<string, int> weights = new Dictionary<string, int>()
    {
        { "X5", 1 },
        { "G2", 2 },
        { "H3", 3 }
    }
    public int CompareTo(myObject other)
    {
        var thisIsSpecial = weights.ContainsKey(this.code);
        var otherIsSpecial = weights.ContainsKey(other.code);
        if (thisIsSpecial && otherIsSpecial)
        {
            return weights[this.code] - weights [other.code];
        }
        else if (thisIsSpecial)
        {
            return -1;
        }
        else if (otherIsSpecial)
        {
            return 1;
        }
        return this.code.CompareTo(other.code);
    }
