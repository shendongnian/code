    public class ButtonViewModel{
    
    private RelayCommand _CloseCommand;
    
    public ICommand CloseCommand
            {
                get { return _CloseCommand?? (_CloseCommand= new RelayCommand(p => Close())); }
            }
    
    void Close(){
    
    //Here u cn write the  logic which close the window from this view model or  raise an event which handled by your button container
    
    }
    }
    
    
        public class RelayCommand : ICommand
        {
            #region Fields
    
            private readonly Action<object> _execute;
            private readonly Predicate<object> _canExecute;
    
            #endregion // Fields
    
            #region Constructors
    
            public RelayCommand(Action<object> execute)
                : this(execute, null)
            {
            }
    
            public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            {
                if (execute == null) throw new ArgumentNullException("execute");
                _execute = execute;
                _canExecute = canExecute;
            }
    
            #endregion // Constructors
    
            #region ICommand Members [DebuggerStepThrough]
    
            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute(parameter);
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
    
            #endregion // ICommand Members }
        }
