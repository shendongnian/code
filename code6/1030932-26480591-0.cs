    private SomeEnum? _value = null;
    
    private SomeEnum CostyCalculation()
    {
        return ...;
    }
    
    public SomeEnum MyVar
    {
       get 
       {
          if (_value == null)
              _value = CostyCalculation();
          return _value.Value;
       }
    }
