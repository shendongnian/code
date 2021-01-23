    using System;
    using System.Windows.Input;
    
    namespace ComboBoxDemo
    {
        public class RelayCommand : ICommand
        {
            private readonly Action<object> execute;
            private readonly Predicate<object> canExecute;
    
            public RelayCommand(Action<object> execute, Predicate<object> canExecute = null )
            {
                if (execute == null)
                    throw new ArgumentNullException("execute");
                this.execute = execute;
                this.canExecute = canExecute;
            }
    
            public bool CanExecute(object parameter)
            {
                if (canExecute == null)
                    return true;
                return canExecute(parameter);
            }
    
            public void Execute(object parameter)
            {
                execute(parameter);
            }
    
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
        }
    }
