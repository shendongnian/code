    private string _labelname;
    public string labelname
    {
        get
        { 
            return _labelname;
        }
  
        set
        {
           _labelname=value;
            OnPropertyChanged("labelname");
        }
    }
