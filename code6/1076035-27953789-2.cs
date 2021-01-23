    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _execute;
     
        public event EventHandler CanExecuteChanged;
     
        public DelegateCommand(Action<object> execute)
        {
            _execute = execute;
        }
     
        public override bool CanExecute(object parameter)
        {
           return true;
        }
     
        public override void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
