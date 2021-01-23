    private string _ActName; 
    public string ActName 
    {
       get
       {
          return _ActName;
       }
       set
       {
          _ActName = value;
          this.HasChanged = true;
          
          //INotifyPropertyChanged stuff if you are using it here.
       }
    }
