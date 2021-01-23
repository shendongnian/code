    public partial class MainWindow : Window
    {
        private string msMapImages = AppDomain.CurrentDomain.BaseDirectory + "Images/";
        private Window win2 { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Image1.Source = new BitmapImage(new Uri(msMapImages + "image.jpg"));
            win2 = new Window2();
            win2.Show();
        }
        private void Btnsend_Click(object sender, RoutedEventArgs e)
        {
            win2.Content = Image1.Source;            
        }
    }
