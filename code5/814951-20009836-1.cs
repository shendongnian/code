    public int CompareTo(Property other)
    {
        var c = this.Value.CompareTo(other.Value);
        if (c == 0) {
            // Same Value, order by Name
            return this.Name.CompareTo(other.Name);
        } else {
            // Different Values
            return c;
        }
    }
