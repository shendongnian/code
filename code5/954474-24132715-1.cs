    public partial class SeekBar : UserControl
    {
        DispatcherTimer Updater = new DispatcherTimer();
        /// <summary>
        /// Initialize new Seekbar
        /// </summary>
        public SeekBar()
        {
            InitializeComponent();
            InitializeUpdater();
        }
        private void InitializeUpdater()
        {
            Updater.Interval = TimeSpan.FromMilliseconds(100);
            Updater.Tick += UpdateSeekBar;
        }
        public MediaElement Player
        {
            get { return (MediaElement)GetValue(PlayerProperty); }
            set { SetValue(PlayerProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Player.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerProperty =
            DependencyProperty.Register("Player", typeof(MediaElement), typeof(SeekBar), new PropertyMetadata(null, OnPlayerChanged));
        private static void OnPlayerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SeekBar seekB = d as SeekBar;
            if (e.OldValue != null)
            {
                SeekBar oldSeekB = (e.OldValue as SeekBar);
                oldSeekB.Player.MediaOpened -= seekB.Player_MediaOpened;
                oldSeekB.Player.MediaEnded -= seekB.Player_MediaEnded;
            }
            if (seekB.Player != null)
            {
                seekB.Player.MediaOpened += seekB.Player_MediaOpened;
                seekB.Player.MediaEnded += seekB.Player_MediaEnded;
            }
        }
        void Player_MediaEnded(object sender, RoutedEventArgs e)
        {
            Updater.Stop();
        }
        private void Player_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (Player.NaturalDuration.HasTimeSpan)
            {
                TotalMilliseconds = Player.NaturalDuration.TimeSpan.TotalMilliseconds;
                Updater.Start();
            }
            else
            {
                CurrentPosition = 0.0;
                TotalMilliseconds = 1.0;
            }
        }
        public double CurrentPosition
        {
            get { return (double)GetValue(CurrentPositionProperty); }
            set { SetValue(CurrentPositionProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CurrentPosition.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPositionProperty =
            DependencyProperty.Register("CurrentPosition", typeof(double), typeof(SeekBar), new PropertyMetadata(1.0, OnCurrentPositionChange));
        private static void OnCurrentPositionChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SeekBar seekB = d as SeekBar;
            if (seekB.Player != null)
            {
                seekB.Player.Position = TimeSpan.FromMilliseconds(seekB.CurrentPosition);
            }
        }
        public double TotalMilliseconds
        {
            get { return (double)GetValue(TotalMillisecondsProperty); }
            set { SetValue(TotalMillisecondsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TotalMilliseconds.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalMillisecondsProperty =
            DependencyProperty.Register("TotalMilliseconds", typeof(double), typeof(SeekBar), new PropertyMetadata(0.0));
        private void UpdateSeekBar(object sender, EventArgs e)
        {
            if (Player != null && TotalMilliseconds > 1)
            {
                CurrentPosition = Player.Position.TotalMilliseconds;
            }
        }
    }
