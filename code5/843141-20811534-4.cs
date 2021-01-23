    public bool IsPortFilterEnabled
    {
        get { return _isPortFilterEnabled; }
        set
        {
            if (_isPortFilterEnabled != value)
            {
                _isPortFilterEnabled = value;
                RefreshOpenPortListView();
            }
        }
    }
    private bool _isPortFilterEnabled = false;
    public string PortToFilter
    {
        get { return _portToFilter ; }
        set
        {
            //
            // Note that setting PortToFilter will turn on the filter
            //
            if(!_isPortFilterEnabled || _portToFilter != value)
            {
                _portToFilter = value;
                RefreshOpenPortListView();
            }
        }
    }
    private string _portToFilter = "0";
