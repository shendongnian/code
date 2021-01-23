    int x = 0;
    public int X
    {
        get
        {
            return x;
        }
        set
        {
            if (value < 0) // A guard condition or some custom condition here
                value = 0;
            x = value;
        }
    }
