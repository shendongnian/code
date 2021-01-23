    public String UIDisplayedString
    {
       get { return _member; }
       set 
       { 
          _member = value;
          PropertyChanged(new PropertyChangedEventArgs("UIDisplayedString"));
       }
