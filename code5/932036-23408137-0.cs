    using System.Net.NetworkInformation;
 
    public partial class MainWindow : Window
    {
        public bool IsAvailable { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
        }
        void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            IsAvailable = e.IsAvailable;
        }
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsAvailable)
            {
                WebBrowser1.Navigate(TextBox1.Text);
            }
            else
            {
                MessageBox.Show("Your Popup Message");
            }
        }
    }
    
