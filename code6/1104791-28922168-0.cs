    public class RelayCommand<T> : ICommand
        where T : class
    {
        private Action<T> execute;
        private Func<T, bool> canExecute;
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter as T);
        }
        public void Execute(object parameter)
        {
            this.execute(parameter as T);
        }
    }
    public class RelayCommand : RelayCommand<object>
    {
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
            : base(execute, canExecute)
        {
        }
    }
