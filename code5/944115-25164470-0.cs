    public partial class GamePage : PhoneApplicationPage
    {
        private LoonieGame _game;
        public GamePage()
        {
            InitializeComponent();
            _game = XamlGame<LoonieGame>.Create("", this);
            this.Unloaded += GamePage_Unloaded;
        }
        void GamePage_Unloaded(object sender, RoutedEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => _game.Dispose());
        }
    }
