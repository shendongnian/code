    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
   
        // Further ICommand implementation omitted...
        public void Invalidate()
        {
            var handler = this.CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
