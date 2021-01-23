    public class MyRoutedCommand : RoutedCommand, ICommand
    {
        private event EventHandler _canExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            var handler = _canExecuteChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
        public new event EventHandler CanExecuteChanged
        {
            add
            {
                _canExecuteChanged += value;
                base.CanExecuteChanged += value;
            }
            remove
            {
                _canExecuteChanged -= value;
                base.CanExecuteChanged -= value;
            }
        }
    }
