    IDictionary<string, object> Panels { get; }
    
    private string _panelValue;
    public string PanelValue
    {
        get { return Panels[panelValue]; }
        set
        {
            // Make sure Panels has this key,
            _panelValue = value;
            OnPropertyChanged("PanelValue");
        }
    }
