    public class MainViewModel
    {
        private Place _place;
        public MainViewModel()
        {
            // create and register new save command
            SaveCommand = new SaveCommand(this);
            CommandManager.RegisterClassCommandBinding(
                typeof(MainViewModel), new CommandBinding(SaveCommand));
        }
        // property to hold place data, exposed in UI
        public Place Place
        {
            get { return _place ?? (_place = new Place()); }
            set { _place = value; }
        }
        public ICommand SaveCommand { get; private set; }
    }
