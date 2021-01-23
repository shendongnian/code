    public override int GetHashCode()
    {
        if(Words == null) return 0;
        unchecked
        {
            int hash = 19;
            foreach (var word in Words)
            {
                hash = hash * 31 + (word == null ? 0 : word.GetHashCode());
            }
            return hash;
        }
    }
