    public override int GetHashCode()
    {
        if (SomeProperty == null || SomeProperty.IsDefault)
            return 0;
        else 
            return SomeProperty.ID.GetHashCode();
    }
