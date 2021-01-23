    public partial class MainWindow : Window
    {
        Window1 window = new Window1();
        public MainWindow()
        {
            InitializeComponent();
            window.Show();
           
        }
        public void Test()
        {
            label1.Content += " works";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            window.Owner = this;
        }
       
    }
