    List<string> _num;
    List<string> num
    {
       get
       {
          return _num;
       }
       set
       {
          _num = value;
    
          // Check the value here and do what you need
          if (_num.Contains("561924630638"))
          { } 
          else if (_num.Contains("561924630638") && _num.Contains("561924630894"))
          { } 
       }
    }
