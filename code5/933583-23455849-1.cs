    public override bool Equals(object obj)
    {
        var compareTo = obj as Emp;
        return Id.Equals(CompareTo.Id);
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
