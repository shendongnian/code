    [DefaultValue(displayFormat.Binary)]
    public displayFormat DisplayFormat
    {
        get { return this.format; }
        set
        { 
            this.format = value; 
            OnPropertyChanged("DisplayFormat"); 
            OnPropertyChanged("MyValue");
        }
    }
