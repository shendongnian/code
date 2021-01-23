    public class MyCommand : ICommand
    {
        private Action _action;
        private Func<bool> _canExecute;
        public MyCommand(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _action();
        }
        public void RaiseCanExecuteChanged()
        { 
            if(CanExecuteChanged!=null)
                CanExecuteChanged(this,new EventArgs());
        }
    }
