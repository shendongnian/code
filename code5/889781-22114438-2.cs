    public TValue this[TKey key]
    {
        get
        {
            int num = this.FindEntry(key);
            if (num >= 0)
            {
                return this.entries[num].value;
            }
            [...]
        }
    public bool TryGetValue(TKey key, out TValue value)
    {
        int num = this.FindEntry(key);
        if (num >= 0)
        {
            ...
        }
