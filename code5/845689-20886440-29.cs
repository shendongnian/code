    public class RelayCommand: ICommand
    {
        private Predicate<object> canExecute;
        private Action<object> execute;
        
        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }
        
        public void Execute(object parameter)
        {
            this.execute.Invoke(parameter);
        }
        public bool CanExecute(object parameter)
        {
            return this.canExecute.Invoke(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
