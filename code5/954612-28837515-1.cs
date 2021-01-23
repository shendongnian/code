    [CommandClass("New")]
    public class NewCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            MessageBox.Show("New");
        }
        public event EventHandler CanExecuteChanged;
    }
