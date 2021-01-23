    public class DelegateCommand : ICommand
    {
        // ICommand implementation omitted...
        public event EventHandler CanExecuteChanged;
        public void Invalidate()
        {
            var handler = this.CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
