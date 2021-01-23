    public class Command : ICommand
    {
        public Action Action { get; set; }
        public void Execute(object parameter)
        {
            if (Action != null)
                Action();
        }
        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }
        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                if (CanExecuteChanged != null)
                    CanExecuteChanged(this, EventArgs.Empty);
            }
        }
        public event EventHandler CanExecuteChanged;
        public Command(Action action)
        {
            Action = action;
        }
    }
