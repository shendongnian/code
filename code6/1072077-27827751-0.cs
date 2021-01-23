    public override int GetHashCode()
    {
        return this.name.GetHashCode();
    }
    public override bool Equals(object b)
    {
        Plant bPlant = b as Plant;
        // If one is null, but not both, return false.
        if (bPlant == null)
        {
            return false;
        }
        // Return true if the fields match:
        return this.name == b.name;
    }
