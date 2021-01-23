    public class RelayCommand : ICommand
        {
            private readonly Action<object> execute;
            private readonly Predicate<object> canExecute;
    
            public RelayCommand(Action<object> exectue, Predicate<object> canExecute = null)
            {
                if (exectue == null)
                    throw new ArgumentNullException("exectue");
                this.execute = exectue;
                this.canExecute = canExecute;
            }
    
            public bool CanExecute(object parameter)
            {
                return this.canExecute == null || this.canExecute(parameter);
            }
    
            public void Execute(object parameter)
            {
                this.execute(parameter);
            }
    
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
        }
