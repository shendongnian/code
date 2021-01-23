    public IEnumerable<string> Names 
    {
         get 
         {
             if(_names == null)
                  _names = new List<string>();
             return _names;
         }
         set
         {
            _names = value;
         }
    }
