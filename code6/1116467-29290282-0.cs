    public partial class JokesMessageBox : Window
    {
        public JokesMessageBox()
        {
            InitializeComponent();
            ReadFile(Path); //example call
        }
        public string Joke
        {
            get { return (string)GetValue(JokeProperty); }
            set { SetValue(JokeProperty, value); }
        }
        public static readonly DependencyProperty JokeProperty =
            DependencyProperty.Register("Joke", typeof(string), typeof(JokesMessageBox), new PropertyMetadata(null));
        public const string Path = "data/jokes.txt";
        public void ReadFile(string path)
        {
            Joke = File.ReadAllText(path);
        }
    }
