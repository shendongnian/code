    public ICommand Command1 { get; set; }
    
    public MainWindowViewModel()
    {
        this.Command1 = new DelegateCommand(ExecuteCommand1, CanExecuteCommand1);
    }
    
        public bool CanExecuteCommand1(object parameter)
        {
            return true;
        }
    
        private void ExecuteCommand1(object parameter)
        {
            ListView listView = parameter as ListView;
    
            foreach (MyObject myObject in listView.SelectedItems)
            {
                // Do stuff.
            }
        }
