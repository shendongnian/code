    // this will serialize sucess only if it is true.
    public bool ShouldSerializeSuccess()
    {
        return Sucess;
    }
    public bool ShouldSerializeName()
    {
        return !String.IsNullOrWhiteSpace(Name) && !Name.Equals("Default");
    }
