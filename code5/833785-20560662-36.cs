    public sealed class SonViewModel
    {
        public SonViewModel()
        {
            InvokeEventCommand = new RelayCommand(() => Event(this, new EventArgs()));
        }
        public event EventHandler Event;
        public ICommand InvokeEventCommand { get; private set; }
    }
