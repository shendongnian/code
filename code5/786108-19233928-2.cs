    public override int GetHashCode()
    {
        if (SomeProperty != null && !SomeProperty.IsDefault)
            return SomeProperty.ID.GetHashCode();
        else 
            return 0;
    }
