    public bool this[TEnum name]
    {
        get
        {
            int index = Convert.ToInt32(name);
            return _bits[index];
        }
    }
