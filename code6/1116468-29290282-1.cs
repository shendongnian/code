    public partial class JokesMessageBox : Window, INotifyPropertyChanged
    {
        public JokesMessageBox()
        {
            InitializeComponent();
            ReadFile(Path); //example call
        }
        private string _joke;
        public string Joke
        {
            get { return _joke; }
            set
            {
                if (string.Equals(value, _joke))
                    return;
                _joke = value;
                OnPropertyChanged("Joke");
            }
        }
        public const string Path = "data/jokes.txt";
        public void ReadFile(string path)
        {
            Joke = File.ReadAllText(path);
        }
        //INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
