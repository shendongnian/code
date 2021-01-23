    public class MainViewModel : ViewModelBase
    {
        // "cache"
        private readonly Cache<User> _cache;
        private SaveCommand _saveCommand;
        public MainViewModel()
        {
            // if exist, deserialize data
            _cache = new Cache<User>();
            User = _cache.Deserialize(typeof(User)) ?? new User();
            // listen properties for changes, serialize
            User.PropertyChanged += (sender, args) => _cache.Serialize(User);
            // provide cache file name to save command
            SaveCommand = new SaveCommand(_cache.File);
            CommandManager.RegisterClassCommandBinding(
                typeof(MainViewModel), new CommandBinding(SaveCommand));
        }
        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(); }
        }
        public ICommand SaveCommand { get; private set; }
    }
