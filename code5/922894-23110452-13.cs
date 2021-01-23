      private RelayCommand _SomeCommand;
      public RelayCommand SomeCommand
        {
            get { return _SomeCommand ?? (_SomeCommand = new RelayCommand(ExecuteSomeCommand, CanExecuteSomeCommand)); }
        }
        private void ExecuteSomeCommand()
        {
            Action t = ()=> 
            {
	            //some action
            };
            
            LockAndDoInBackground(t, "Generating Information...");
        }
        private bool CanExecuteSomeCommand()
        {
            return SelectedItem != null;
        }
