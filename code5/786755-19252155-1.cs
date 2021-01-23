     private ICommand _onCopmboBoxSelectionChangedCommand;
     public ICommand OnCopmboBoxSelectionChangedCommand
     {
         get
         {
             if (_onCopmboBoxSelectionChangedCommand != null) return _onCopmboBoxSelectionChangedCommand;
             _onCopmboBoxSelectionChangedCommand = new RelayCommand(OnCopmboBoxSelectionChanged);
             return _onCopmboBoxSelectionChangedCommand;
         }
     }
