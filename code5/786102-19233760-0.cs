    public override int GetHashCode()
    {
        if (SomeProperty == null || SomeProperty.IsDefault)
            return base.GetHashCode() ;
        else return SomeProperty.ID.GetHashCode();
    }
