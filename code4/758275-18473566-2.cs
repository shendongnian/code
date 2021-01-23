    using System;
    using System.Windows.Input;
    namespace Commanding
    {
        public class RelayCommand : ICommand
        {   //http://msdn.microsoft.com/en-us/magazine/dd419663.aspx
            public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            {
                _execute = execute;
                _canExecute = canExecute;
            }
            public bool CanExecute(object parameter)
            {
                return _canExecute(parameter);
            }
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
            public void Execute(object parameter)
            {
                _execute(parameter);
            }
            private readonly Action<object> _execute;
            private readonly Predicate<object> _canExecute;
        }
    }
