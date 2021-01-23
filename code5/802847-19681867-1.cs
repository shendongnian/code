    public class RelayCommand : ICommand
    {
        public RelayCommand(Action<object> execute)
        {
             this._execute = execute;
             ...
        }
        
        ...
    
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    } 
