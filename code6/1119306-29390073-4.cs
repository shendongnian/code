    // This class is not fully implemented. Replace by your own DelegateCommand or
    // Grab an ICommand implementation from any of the well known MVVM Frameworks out there.
    // This only exists for the sake of the example.
    public class Command : ICommand
    {
        private readonly Action action;
        public string DisplayName { get; private set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            action();
        }
        public Command(string displayName, Action action)
        {
            this.action = action;
            this.DisplayName = displayName;
        }
    }
