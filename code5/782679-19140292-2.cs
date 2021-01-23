    class TestCommand : ICommand {
        public event EventHandler CanExecuteChanged { get; set; }
        public bool CanExecute(object parameter)
        {
            return true; // Expresses whether the command is operable or disabled.
        }
        public void Execute(object parameter)
        {
             // The code to execute here when the command fires.
        }
    }
