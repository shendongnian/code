    public sealed class UserControlViewModel
    {
        public UserControlViewModel()
        {
            InvokeEventCommand = new RelayCommand(() => Event(this, new EventArgs()));
        }
        public event EventHandler Event;
        public ICommand InvokeEventCommand { get; private set; }
    }
