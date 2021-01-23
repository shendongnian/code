    private DateTime? _date;
    public DateTime? Date
    {
        get 
        {
            if (null == _date)
            {
                //Set some initial value
                //or just return some default value without setting the property
            }
            return _date; 
        }
        set
        {
            if (value != _date)
            {
                _date = value;
                this.OnPropertyChanged("Date");
            }
        }
    }
