    private RelayCommand _saveCommand;
    
     public ICommand SaveCommand
            {
                get { return _saveCommand ?? (_saveCommand = new RelayCommand(p => Save(), p => CanSave())); }
            }
        private void Save()
        {
         // Saving code
            
           
        }
