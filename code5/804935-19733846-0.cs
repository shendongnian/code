    public MyCommandDefinition SelectedCommand
    {
        get { return _selectedCommand; }
        set
        {
    
            if (value == null)
              return;
    
            _selectedCommand = value;
            NotifyPropertyChange(() => SelectedCommand);
    
            if (SelectedCommand.DisplayName == _setOutput) //**NullReferenceException on this line!
            {
                //Commands to change values in model
            }
    
            if(...) { ... } 
        }
    }
