    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 31 + CountryId.GetHashCode();
        hash = hash * 31 + City.GetHashCode();
        return hash;
    }
