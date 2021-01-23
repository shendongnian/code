    public partial class JokesMessageBox : Window, INotifyPropertyChanged
        {
            public JokesMessageBox()
            {
                InitializeComponent();
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public string Joke { get; set; }
            public string path = "data/jokes.txt";
    
            public void ReadFile(string path)
            {
                Joke = File.ReadAllText(path);
                OnPropertyChanged("Joke");
            }
    
            private void OnPropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
