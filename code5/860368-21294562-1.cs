    public static string ConnectionString
    {
        get
        {
            if (_ConnectionString == null)
                _ConnectionString = FunctionToDynamicallyCreateConnectionstring();
            return _ConnectionString;
        }
    }
