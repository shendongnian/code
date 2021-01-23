    public bool this[TEnum name]
    {
        get
        {
            int index = (int)(object)name;
            return _bits[index];
        }
    }
