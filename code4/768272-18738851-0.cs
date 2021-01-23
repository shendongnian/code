    public class Command : ICommand
    {
        public void Execute(object parameter)
        {
            // Do whatever you have to do
        }
    
        public bool CanExecute(object parameter)
        {
            return true;
        }
    
        public event EventHandler CanExecuteChanged;
    }
