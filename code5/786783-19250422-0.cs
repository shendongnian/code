    public int KeyGen(string a, string b, string c)
    {
        var aHash = a.GetHashCode();
        var bHash = b.GetHashCode();
        var cHash = c.GetHashCode();
        var hash = 36469;
        unchecked
        {
            hash = hash * 17 + aHash;
            hash = hash * 17 + bHash;
            hash = hash * 17 + cHash;
        }
        return hash;
    }
