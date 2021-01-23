    public ICommand CloseTabCommand
    {
        get
        {
            if (_closeTabCommand == null)                
                _closeTabCommand = new RelayCommand(param => this.CloseTab(param),
                                                             null);
            return _closeTabCommand;
        }            
    }
    private void CloseTab(object param)
    {
        TabItem tabItem = (TabItem)param;
        this.Tabs.Remove(tabItem);
    }
