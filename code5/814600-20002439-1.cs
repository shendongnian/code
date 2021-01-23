    public override int GetHashCode()
    {
        unchecked // Overflow is fine, just wrap
        {
            int hash = 17;
            // Suitable nullity checks etc, of course :)
            hash = hash * 23 + field1.GetHashCode();
            hash = hash * 23 + field2.GetHashCode();
            hash = hash * 23 + field3.GetHashCode();
            return hash;
        }
    }
