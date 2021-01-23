    public override int GetHashCode()
    {
        int hashCode = this.GetType()
                           .GetProperties()                // Get property names.
                           .Select(o => o.GetValue(this))  // Look up all property values.
                           .GetHashCode();                 // Combine all into hashcode.
        return hashCode;
    }
