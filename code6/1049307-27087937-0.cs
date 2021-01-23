    private string _title;
    public string Title
    {
          get
           {
                return _title;
           }
           set
           {
               if(_title!=value)
               {
                   _title=value;
                   OnPropertyChanged("Title");
               }
           }
    }
