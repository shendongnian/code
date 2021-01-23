    /// <summary>
    /// The <see cref="NameList" /> property's name.
    /// </summary>
    public const string NameListPropertyName = "NameList";
    /// <summary>
    /// Sets and gets the NameList property.
    /// Changes to that property's value raise the PropertyChanged event.
    /// </summary>
    public List<string> NameList
    {
        get
        {
            return _nameList;
        }
        set
        {
            if (_nameList == value)
            {
                return;
            }
            RaisePropertyChanging(NameListPropertyName);
            _nameList = value;
            RaisePropertyChanged(NameListPropertyName);
        }
    }
    private List<string> _nameList = new List<string>( );
