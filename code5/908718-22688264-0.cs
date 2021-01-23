    private SqlByte _AutomaticFlag;
    public SqlByte AutomaticFlag
    {
        get { return _AutomaticFlag; }
        set
        {
            if (AutomaticFlagBoolean)
            {
                _AutomaticFlag = 1;
            }
            else
            {
                _AutomaticFlag = 0;
            }
        }
    }
