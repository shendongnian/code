    public MainViewModel()
        {
            DoSomethingCommand= new DelegateCommand(DoSomethingCommandExec, DoSomethingCommandCanExec);
        }
 
        public ICommand DoSomethingCommand{ get; private set; }
 
        private bool DoSomethingCommandCanExec()
        {
            return true;
        }
 
        private void DoSomethingCommandExec()
        {
            // DoSomethingCommand
        }
