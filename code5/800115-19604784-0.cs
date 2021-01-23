    public WorkspaceViewModel SelectedTab
    {
        get { return _selectedTab; }
        set
        {
            _selectedTab = value;
            RaisePropertyChanged(() => SelectedTab);
        }
    }
