    public partial class MainPage : PhoneApplicationPage
    {
        private double totalSeconds = 1;
        DispatcherTimer timer = new DispatcherTimer();
        private void player_MediaOpened(object sender, RoutedEventArgs e)
        {
            totalSeconds = (sender as MediaElement).NaturalDuration.TimeSpan.TotalSeconds;
        }
        public MainPage()
        {
            InitializeComponent();
            Play.Click += Play_Click;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => { playerSeekBar.Value += (double)(1 / totalSeconds); };
            playerSeekBar.LostMouseCapture += (s, e) =>
            { player.Position = TimeSpan.FromSeconds(playerSeekBar.Value * totalSeconds); };
        }
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            player.AutoPlay = true;
            player.Source = new Uri("music.mp3", UriKind.RelativeOrAbsolute);
            timer.Start();  // DON'T forget to start the timer.
        }
    }
