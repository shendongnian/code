    // simple main form with a button to open the 2nd form
    public partial class MainWindow : Window
    {
        public MainWindow() { InitializeComponent(); }
        private void Button_Click(object sender, RoutedEventArgs e) { new PopupWindow().Show(); }
    }
    // 2nd popup window constructor (hence background worker) fires after form is closed and re-opened from the main form
    public partial class PopupWindow : Window
    {
        public PopupWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            var testThread = new BackgroundWorker();
            {
                testThread.DoWork += (sender, args) => { MessageBox.Show("doWork running"); };
                testThread.RunWorkerCompleted += (sender, args) => { MessageBox.Show("doWork completed"); };
                testThread.WorkerSupportsCancellation = true;
                testThread.RunWorkerAsync();
            }
        }
    }
