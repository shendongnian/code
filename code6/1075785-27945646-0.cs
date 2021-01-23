    public class ViewModel : INotifyPropertyChanged
        {
            public BaseCommand GetDataCommand { get; set; }
    
            public ViewModel()
            {
                GetDataCommand = new BaseCommand(GetData);            
            }
    
            private void GetData(object param)
            {
                
            }  
        }
    
        public class BaseCommand : ICommand
        {
            private Predicate<object> _canExecute;
            private Action<object> _method;
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
            
            public BaseCommand(Action<object> method, Predicate<object> canExecute=null)
            {
                _method = method;
                _canExecute = canExecute;
            }
    
            public bool CanExecute(object parameter)
            {
                if (_canExecute == null)
                {
                    return true;
                }
    
                return _canExecute(parameter);
            }
    
            public void Execute(object parameter)
            {
                _method.Invoke(parameter);
            }
        }
