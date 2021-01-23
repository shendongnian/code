    public override bool Equals(object other)
    {
        var otherKey = other as GroupKey;
            
        if (otherKey == null)
        {
            return false;
        }
            
        return otherKey.Id1 == this.Id1 && otherKey.Id2 == this.Id2;
    }
        
    public override int GetHashCode()
    {
        return this.Id1.GetHashCode() ^ this.Id2.GetHashCode();
    }
