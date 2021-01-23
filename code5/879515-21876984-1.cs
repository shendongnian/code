    public class GenericRelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        public Predicate<T> CanExecuteFunc { get; private set; }
    
        public GenericRelayCommand(Action<T> execute) : this(execute, p => true)
        {}
        
        public GenericRelayCommand(Action<T> execute, Predicate<T> canExecuteFunc)
        {
            _execute = execute;
            CanExecuteFunc = canExecuteFunc;
        }
    
        public bool CanExecute(object parameter)
        {
            var canExecute = CanExecuteFunc((T)parameter);
            return canExecute;
        }
    
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
