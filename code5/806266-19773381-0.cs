    public partial class MainWindow : Window
        {
            private System.Windows.Threading.DispatcherTimer pbTimer;
            private int pbProgress = 0;
            
            public MainWindow()
            {
                InitializeComponent();
                pbTimer = new System.Windows.Threading.DispatcherTimer();
                pbTimer.Tick += new EventHandler(ProgressUpdate);
                pbTimer.Interval = new TimeSpan(0, 0, 1);
            }
    
            private void ProgressUpdate(object sender, EventArgs e)
            {
                if (pbProgress < 100)
                {
                    pBar.Value = ++pbProgress;
                }
            }
    
            private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
            {
                pbTimer.Start();
            }
    
            private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
            {
                pbTimer.Stop();
                pBar.Value = 0;
                pbProgress = 0;
            }
        }
