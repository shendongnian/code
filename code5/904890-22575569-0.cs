    /// <summary>
    /// Workaround for the hyperlink click issue. What the hell is going on?
    /// </summary>
    public class DummyCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
        }
        public event EventHandler CanExecuteChanged;
    }
