        // In this case we need INotifyPropertyChanged - 
        public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
        {
        // implementing interface
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string property = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        // Property for Binding
        public double SlideValue
        {
            get { return player.Position.TotalSeconds; }
            set { player.Position = TimeSpan.FromSeconds(value); }
        }
        DispatcherTimer timer = new DispatcherTimer(); // timer
        // Get the duration when Media File is opened
        private void player_MediaOpened(object sender, RoutedEventArgs e)
        {
            playerSeekBar.Maximum = (sender as MediaElement).NaturalDuration.TimeSpan.TotalSeconds;
        }
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = this;  // Set the DataContext
            Play.Click += Play_Click;  // My play method
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => { RaiseProperty("SlideValue"); };
        }
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            player.AutoPlay = true;
            player.Source = new Uri("music.mp3", UriKind.RelativeOrAbsolute);
            timer.Start();  // DON'T forget to start the timer.
        }
