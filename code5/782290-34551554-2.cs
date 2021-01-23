    public class RelayCommand : ICommand
    {
        #region Private Readonly Properties
        private readonly Action<object> executeCommand;
        private readonly Predicate<object> canExecute;
        #endregion
        #region Constructors
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null) 
                throw new ArgumentNullException("execute");
            this.executeCommand = execute; 
            this.canExecute = canExecute;
        }
        #endregion
        #region Public ICommand Members
        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            executeCommand(parameter);
        }
        #endregion
    }
