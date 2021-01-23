    public class SimpleCommand : ICommand
    {
       
        private readonly Predicate<object> _canExecuteDelegate;
        private readonly Action<object> _executeDelegate;
        #region Constructors
        public SimpleCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public SimpleCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _executeDelegate = execute;
            _canExecuteDelegate = canExecute;
        }
        #endregion // Constructors
        #region ICommand Members
        public virtual bool CanExecute(object parameter)
        {
            return _canExecuteDelegate == null || _canExecuteDelegate(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            _executeDelegate(parameter);
        }
        #endregion
    }
