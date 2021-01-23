    using System; 
    using Microsoft.Phone.Controls; 
    using System.Windows.Threading;  
    namespace Clock 
    {
        public partial class MainPage : PhoneApplicationPage
        {
            DispatcherTimer refreshTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(60) };
            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainPage_Loaded;
            }
            void MainPage_Loaded(object sender, RoutedEventArgs e)
            {
                DoStuff();
                this.refreshTimer.Tick += new EventHandler(RefreshTimer_Tick);
                refreshTimer.Start();
            }
            private void RefreshTimer_Tick(object sender, EventArgs e)
            {
                DoStuff();
            }
            private void DoStuff()
            {
                //Do stuff
                lastUpdateLabel.Content = DateTime.Now.ToLongTimeString();
            }
        }
    }
