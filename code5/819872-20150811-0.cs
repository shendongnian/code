    public bool Equals(HalfDay other)
    {
        if (object.ReferenceEquals(other, null))
            return false;
        if (object.ReferenceEquals(other, this))
            return true;
       return this.Date.Date == other.Date.Date && this.Half == other.Half;
    }
    public int GetHashCode()
    {
        // TODO
    }
    public override bool Equals(object other)
    {
        return Equals(other as HalfDay);
    }
    public static bool operator ==(HalfDay halfday1, HalfDay halfday2)
    {
        return object.Equals(halfday1, halfday2);
    }
    public static bool operator !=(HalfDay halfday1, HalfDay halfday2)
    {
        return !(halfday1 == halfday2);
    }
