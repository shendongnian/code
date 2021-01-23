    public int keygen(string a, string b, string c)
    {
        unchecked // Overflow is fine, just wrap
        {
            int hash = 17;
            hash = hash * 23 + a == null ? 0 : a.GetHashCode();
            hash = hash * 23 + b == null ? 0 : b.GetHashCode();
            hash = hash * 23 + c == null ? 0 : c.GetHashCode();
            return hash;
        }
    }
