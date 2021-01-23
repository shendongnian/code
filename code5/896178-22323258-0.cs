    private Model_selectedModel;
    public Mode SelectedModel
    {
        get 
        {
            return _selectedModel; 
        }
        set
        {
            if (_selectedModel != value)
            {
                _selectedModel = value;
                NotifyPropertyChanged("SelectedModel");
            }
        }
    }
