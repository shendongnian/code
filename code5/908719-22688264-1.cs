    private SqlByte _automaticFlag;
    private bool _automaticFlagBoolean;
    
    public SqlByte AutomaticFlag
    {
        get { return _automaticFlag; }
        set
        {
            _automaticFlag = value;
            _automaticFlagBoolean = (_automaticFlag != 0);
        }
    }
    
    public bool AutomaticFlagBoolean
    {
        get
        {
            return _AutomaticFlagBookean;
        }
        set { _automaticFlagBoolean = value; 
           if (_automaticFlagBoolean) {
              _automaticFlag = 1;
           } else {
              _automaticFlag = 0;
           }
        }
    }
