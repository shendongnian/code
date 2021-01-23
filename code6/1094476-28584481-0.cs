    public ICommand AddCommand
        {
            get;
            internal set;
        }
        private void CreateAddCommand()
        {
            CancelCommand = new RelayCommand(ExecuteCancel, CanExecuteCancelCommand);
        }
        private void ExecuteAdd(object obj)
        {
           //Here is Your code
        }
        private bool CanExecuteAddCommand(object obj)
        {
            return true;//return the value based on conditions here is button enable or desabled condition.
        }
