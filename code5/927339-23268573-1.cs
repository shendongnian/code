    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            button_Click(null, null);
            var timer = new Timer(1000);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
                {
                    var rand = new Random();
                    Updateable.Background =
                        new SolidColorBrush(Color.FromRgb((byte) rand.Next(byte.MaxValue),
                                                          (byte) rand.Next(byte.MaxValue),
                                                          (byte) rand.Next(byte.MaxValue)));
                }));
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var button = new Button {Content = "Click Me!"};
            button.Click += button_Click;
            Controls.Children.Add(button);
        }
        private void MainWindow_OnLayoutUpdated(object sender, EventArgs eventArgs)
        {
            LastEvent.Text = DateTime.Now.ToLongTimeString();
        }
    }
