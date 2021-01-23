    public bool Equals(objTest other)
    {
        return this.index == other.index;
    }
    public override bool Equals(object other)
    {
        var o = other as objTest;
        return o != null && Equals(o);
    }
    public override int GetHashCode()
    {
        return index.GetHashCode();
    }
