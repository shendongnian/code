    public override bool Equals(object other)
    {
        if (!this.HasValue)
        {
            return (other == null);
        }
        if (other == null)
        {
            return false;
        }
        return this.value.Equals(other);
    }
