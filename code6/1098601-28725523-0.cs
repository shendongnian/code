    public IList<ChartData> BindSelectedItems
    {
        get 
        { 
            return _bindSelectedItems; 
        }
        set
        {
            _bindSelectedItems = value;
    
            RaisePropertyChanged("BindSelectedItems");
        }
    }
    
    IList<ChartData> _bindSelectedItems;
