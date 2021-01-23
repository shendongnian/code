     public ViewModel()
     {
     SaveCommand2 = new DelegateCommand(new Action(() =>
                    {
    			      //Your action stuff.
                    }), SaveCommand_CanExecute);
     }
    
     bool SaveCommand_CanExecute()
     {
            return Model.Name != string.Empty;
     }
