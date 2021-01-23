        public MainViewModel()
        {
            Command1 = new RelayCommand(OnCommand1Executed, () => true);
            Command2 = new RelayCommand(OnCommand2Executed, OnCommand2CanExecute);
        }
        private void OnCommand1Executed()
        {
            _command2CanExecute = true;
        }
        private void OnCommand2Executed()
        {
            // Not implemented
        }
        private bool OnCommand2CanExecute()
        {
            return _command2CanExecute;
        }
