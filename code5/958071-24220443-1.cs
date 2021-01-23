    public int CompareTo(MyClass other)
    {
        if(other.Equals(this))
            return 0;
        var result = other.Date.CompareTo(Date);
        if(result != 0)
            return result;
        result = other.ID1.CompareTo(ID1);
        if(result != 0)
            return result;
        return other.ID2.CompareTo(ID2);
    }
