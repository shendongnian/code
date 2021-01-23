    public override int GetHashCode()
    {
        int hash = 19;
        hash = hash * 23 + s1.GetHashCode();
        hash = hash * 23 + s2.GetHashCode();
        return hash;
    }
