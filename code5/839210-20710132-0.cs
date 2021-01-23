    private static readonly ClassName _this = new ClassName();
    
    public object ProxySelectedItem
    {
        get { return SelectedItem; }
        set { SelectedItem = value; }
    }
    
    private static object _selectedItem;
    public static object SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            if (SelectedItem != null)
            {
                _this.EnableDisable = true;
            }
            else
            {
                _this.EnableDisable = false;
            }
            _selectedItem = value;
            _this.OnPropertyChanged("ProxySelectedItem");
        }
    }
    
    private bool _enableDisable;
    public bool EnableDisable
    {
        get { return _enableDisable; }
        set 
        {
            _enableDisable = value;
            OnPropertyChanged("EnableDisable"); 
        }
    }
