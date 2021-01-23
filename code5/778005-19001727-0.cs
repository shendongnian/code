    public override string ToString()
    {
       ... any serialization will do, for instance JSON or CSV or XML ...
    }
    
    
    public override bool Equals(System.Object obj)
    {
        return (this.ToString().Equals(obj.ToString());
    }
    
    
    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }
