    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TimerTabItem item = new TimerTabItem();
            item.Unloaded += ItemOnUnloaded;
            tabControl.Items.Add(item);
        }
        private void ItemOnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            (sender as TimerTabItem).Dispose();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tabControl.Items.Remove(tabControl.Items[0]);
        }
    }
    class TimerTabItem : TabItem, IDisposable
    {
        private DispatcherTimer MyTimer { get; set; }
        public TimerTabItem() : base()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 3);
            timer.Tick += TimerOnTick;
            timer.Start();
            MyTimer = timer;
        }
        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            MessageBox.Show("Hello!");
        }
        #region Implementation of IDisposable
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            MyTimer.Stop();
            MyTimer.Tick -= TimerOnTick;
            MyTimer = null;
        }
        #endregion
    }
