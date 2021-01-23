    public class MyCommand : ICommand
    {
        // Helper delegate. In C# 6.0 use: 
        // private bool True() => true;
        private readonly Func<bool> _true = () => true;
        private readonly Action _execute;
        private Func<bool> _canExecute;
        private Func<bool> _isVisible;
        public event EventHandler IsVisibleChanged;
        public event EventHandler CanExecuteChanged;
        public MyCommand(Action execute, Func<bool> canExecute = null, Func<bool> isVisible = null)
        {
            _execute = execute;
            _canExecute = canExecute ?? _true;
            _isVisible = isVisible ?? _true;
        }
        public void Execute()
        {
            _execute();
        }
        public Func<bool> CanExecute
        {
            set
            {
                _canExecute = value ?? _true;
                CanExecuteChanged(this, new EventArgs());
            }
            get { return _canExecute; }
        }
        public Func<bool> IsVisible
        {
            set
            {
                _isVisible = value ?? _true;
                IsVisibleChanged(this, new EventArgs());
            }
            get { return _isVisible; }
        }
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }
        void ICommand.Execute(object parameter)
        {
            Execute();
        }
    }
