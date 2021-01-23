    class CommandHandler:ICommand
    {
        private Action action;
        private Func<bool> isEnabled;
        public CommandHandler(Action _action, Func<bool> _isEnabled)
        {
            action = _action;
            isEnabled = _isEnabled;
        }
        public bool CanExecute(object parameter)
        {
            return isEnabled();
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            action();
        }
    }
