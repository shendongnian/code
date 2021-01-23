    public sealed class AsyncDelegateCommand : ICommand
    {
       private readonly Func<bool> _canExecute;
       private readonly Func<Task> _executeAsync;
       private Task _currentExecution;
    
       public AsyncDelegateCommand(Func<Task> executeAsync)
          : this(executeAsync, null)
       {
       }
    
       public AsyncDelegateCommand(Func<Task> executeAsync, Func<bool> canExecute)
       {
          if (executeAsync == null) throw new ArgumentNullException("executeAsync");
          _executeAsync = executeAsync;
          _canExecute = canExecute;
       }
    
       public event EventHandler CanExecuteChanged
       {
          add { CommandManager.RequerySuggested += value; }
          remove { CommandManager.RequerySuggested -= value; }
       }
    
       public bool CanExecute(object parameter)
       {
          if (_currentExecution != null && !_currentExecution.IsCompleted)
          {
             return false;
          }
    
          return _canExecute == null || _canExecute();
       }
    
       public async void Execute(object parameter)
       {
          try
          {
             _currentExecution = _executeAsync();
             await _currentExecution;
          }
          finally
          {
             _currentExecution = null;
             CommandManager.InvalidateRequerySuggested();
          }
       }
    }
