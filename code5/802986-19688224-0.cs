    public class RelayCommand : ICommand
    {
        private Func<bool> _canExecute;
        private Action _execute;
        public RelayCommand(Action execute , Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            var temp = Volatile.Read(ref CanExecuteChanged);
            if (temp != null)
                temp(this, new EventArgs());
        }
        public void Execute(object parameter)
        {
            _execute();
        }
    }
