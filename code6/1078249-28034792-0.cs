    public bool Equals(MyType other)
    {
        // if 'other' is a null reference, or if 'other' is more derived or less derived
        if ((object)other == (object)null || other.GetType() != GetType())
            return false;
        // OK, check members (assuming 'Id' has a type that makes '==' a wise choice)
        return Id == other.Id;
    }
    public override bool Equals(object obj)
    {
        // call to other overload
        return Equals(obj as MyType);
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
