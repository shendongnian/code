    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MyFlyout.Hide();
        }
    }
