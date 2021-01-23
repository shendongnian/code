     public partial class MainWindow : Window
    {
        private System.Threading.Timer _timer;
        public MainWindow()
        {            
            InitializeComponent();
            _timer = new Timer(new System.Threading.TimerCallback(Process), null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }
        private void Process(object state)
        {
            DateTime dt = DateTime.Now;
            System.Threading.Thread.Sleep(3000);
            Debug.WriteLine("dt=" + dt.ToString("HH:mm:ss.fff") + " Now=" + DateTime.Now.ToString("HH:mm:ss.fff"));
        }
    }
