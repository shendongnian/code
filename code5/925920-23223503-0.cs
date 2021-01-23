    public DateTime Date // Bind with DatePicker
    {
        get { return date; }
        set 
        {
            date = value;
            NotifyPropertyChanged("Date");
            IsFormatted = YourLogicHere();
        }
    }
    public bool IsFormatted { get; set; }
    public string DateValue
    {
        get { return IsFormatted ? Date.ToString("ddd, ddMMM") : Date.ToString(); }
    }
