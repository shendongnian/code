    public string Prop
    {
      get
      {
          return _prop;
      }
      set
      {
          if (_prop != value) 
          {
              _prop = value;
              OnPropertyChanged(()=>Prop);
          }
       }   
    } 
