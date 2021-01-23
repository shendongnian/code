    public override bool Equals(object o)
    {
        if (!(o is Person)) { return false; }
        return ((Person)o).Id == this.Id;
    }
    public override int GetHashCode()
    {
        return this.Id;
    }
