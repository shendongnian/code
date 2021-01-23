        public MainWindowViewModel()
        {
            PassSelectedValueToXmlCommand = new DelegateCommand<string>(HandleCommand);
        }
        
        public ICommand PassSelectedValueToXmlCommand { get; set; }
        private void HandleCommand(string parameter)
        {
            MessageBox.Show(String.Format("Parameter with value {0} was received by ViewModel", parameter));
        }
