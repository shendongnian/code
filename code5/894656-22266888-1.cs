    private RelayCommand _searchCommand = null;
    public ICommand SearchCommand
    {
        get
        {
            if (_searchCommand == null)
            {
                _searchCommand = new RelayCommand(param => this.Search(param), param => true);
            }
            return _searchCommand;
        }
    }
    private void Search(object param)
    {
        bool parameter = (bool)param;
        if (parameter) 
        {
            MessageBox.Show("Pressed the Enter Key");
        }
    }
