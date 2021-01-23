    public MyCommandDefinition SelectedCommand
    {
        get { return _selectedCommand; }
        set
        {
            _selectedCommand = value;
            NotifyPropertyChange(() => SelectedCommand);
    
            if (SelectedCommand != null && SelectedCommand.DisplayName == _setOutput) 
            {
                //Commands to change values in model
            }
    
            if(...) { ... } 
        }
    }
