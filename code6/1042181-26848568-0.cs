    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TimerTabItem item = new TimerTabItem();
            tabControl.Items.Add(item);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tabControl.Items.Remove(tabControl.Items[0]);
        }
    }
    class TimerTabItem : TabItem
    {
        private Timer MyTimer { get; set; }
        public TimerTabItem() : base()
        {
            Timer timer = new Timer();
            timer.Elapsed += (sender, args) => { MessageBox.Show("Hello"); };
            timer.Interval = 3000;
            timer.Enabled = true;
            MyTimer = timer;
            Unloaded += OnUnloaded;
        }
        private void OnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            MyTimer.Enabled = false;
            MyTimer.Dispose();
        }
    }
