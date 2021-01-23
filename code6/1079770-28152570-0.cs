    public override bool Equals(Object input)
    {
      return Id == ((Thing)input)?.Id;
    }
    
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }
