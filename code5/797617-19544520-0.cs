    public int Property
    {
        get { return _property; }
        set
        {
            int oldValue;
            do
            {
                oldValue = _property;
            } while (oldValue != Interlocked.CompareExchange(ref _property, value, oldValue))
        }
    }
