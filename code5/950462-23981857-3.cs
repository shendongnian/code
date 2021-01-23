    using System;
    using System.Windows.Input;
    namespace yourSolution.ViewModel
    {
   
    public class DelegateCommand : ICommand
    {
        private readonly Action<Object> _Execute; 
        private readonly Func<Object, Boolean> _CanExecute; 
       
        public DelegateCommand(Action<Object> execute) : this(null, execute) { }
    
        public DelegateCommand(Func<Object, Boolean> canExecute, Action<Object> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _Execute = execute;
            _CanExecute = canExecute;
        }
      
        public event EventHandler CanExecuteChanged;
       
        public Boolean CanExecute(Object parameter)
        {
            return _CanExecute == null ? true : _CanExecute(parameter);
        }
     
        public void Execute(Object parameter)
        {
            _Execute(parameter);
        }
        
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
    }
