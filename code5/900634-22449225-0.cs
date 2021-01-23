    public override bool Equals(object obj)
    {
        Child other = obj as Child;
        if (other == null)
            return false;
        return other.Name == Name;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
