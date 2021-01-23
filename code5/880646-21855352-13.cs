        class MyCommand : ICommand
        {
            public delegate void ICommandOnExecute(object parameter);
            public delegate bool ICommandOnCanExecute(object parameter);
            private ICommandOnExecute _execute;
    	    private ICommandOnCanExecute _canExecute;
    
            public bool CanExecute(object parameter)
            {
                return _canExecute.Invoke(parameter);
            }
            public MyCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
    	    {
    		_execute = onExecuteMethod;
    		_canExecute = onCanExecuteMethod;
    	    }
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
    
            public void Execute(object parameter)
            {
                _execute.Invoke(parameter);
            }
        }
