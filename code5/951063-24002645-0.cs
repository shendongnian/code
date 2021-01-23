        private ICommand _processCommand;
        public ICommand ProcessCommand
        {
            get { return _processCommand ?? (_processCommand = new DelegateCommand(Process, CanProcess)); }
        }
        private bool CanProcess(object obj)
        {
            return ViewModel.ProcessCommand.CanExecute(obj);
        }
        private void Process(object obj)
        {
            ViewModel.ProcessCommand.Execute(obj);
            // Do UI specific stuff...
        }
