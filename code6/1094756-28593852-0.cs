    //This is a simplified model for answering the OP's question, the real one is more complex.
    private List<List<TValue> _bucket = //....
    
    public bool ContainsKey(TKey key)
    {
        List<TKey> bucket = _buckets[key.GetHashCode() % _buckets.Length];
        foreach(var item in bucket)
        {
            if(key.Equals(item))
                return true;
        }
        return false;
    }
