    public FilterType FilterType
    {
        get { return filterType; }
        set
        {
            filterType = value; 
            NotifyPropertyChange("FilterType");
            FillAvailableDatesDependantOnFilterType();
        }
    }
...  
    private void FillAvailableDatesDependantOnFilterType()
    {
        AvailableDates = new ObservableCollection<DateTime>();
        if (FilterType == "Today") AvailableDates.Add(DateTime.Now.Date);
        ...
    }
