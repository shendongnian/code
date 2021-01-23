    public string InsertName
    {
        get { return insertName;  }
        set { 
            if (value != insertname)
            {
                insertName = value; 
            }
            OnPropertyChanged(() => InsertName);
            // or OnPropertyChanged("InsertName");
        }
    }
