    internal class RelayCommand : ICommand
    {
        ...
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        ...
    }
