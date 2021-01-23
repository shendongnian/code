    public bool Equals(Catalog cat)
    {
        return (this.Name.Equals(cat.Name));
    }
    public int GetHashCode(object obj)
    {
        // implement your hash code logic here
        return obj.ToString().GetHashCode();
    }
