    DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
    TimeSpan time;
    public MainPage()
    {
        this.InitializeComponent();
        timer.Tick += (sender, e) =>
            {
                time -= TimeSpan.FromSeconds(1);
                if (time <= TimeSpan.Zero) timer.Stop();
                myTextBlock.Text = time.ToString(@"mm\:ss");
            };
    }
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    { time = TimeSpan.FromMinutes(int.Parse((sender as TextBox).Text)); }
    private void startBtn_Click(object sender, RoutedEventArgs e)
    { timer.Start(); }
