    private string _chars;
    
    public string Chars
    {
      get { return _chars; }
      set 
      { 
        DoSomeThingSpecialWhenEdited();
        _chars = value;
      }
    }
