    public override bool Equals(object o)
    {
        var cast = o as Person;
        if (cast == null) 
            return false; 
        return cast.Id == this.Id;
    }
    
    public override int GetHashCode()
    {
        return this.Id;
    }
