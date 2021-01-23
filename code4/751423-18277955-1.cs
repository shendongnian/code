    public bool this[TEnum name]
    {
        get
        {
            long index = Convert.ToInt32(name);
            return _bits[index];
        }
    }
