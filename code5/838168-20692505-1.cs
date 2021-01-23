     public class RelayCommand : IDelegateCommand
    {
        readonly protected Predicate<object> _canExecute;
        readonly protected Action<object> _execute;      
        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            _canExecute = canExecute;
            _execute = execute;          
        }
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }      
        public virtual bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged;
        public virtual void Execute(object parameter)
        {
            _execute(parameter);
        }      
    }
