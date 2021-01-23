    public partial class MainWindow : Window
    {
    
        public MainWindow()
        {
            InitializeComponent();
        }
    
        public void btnStart_Click(object sender, RoutedEventArgs e)
            {
                Task.Factory.StartNew(() =>
                {
                    APPexample Example = new APPexample();
                    Example.Run();
                }
            }
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Example.StopRunning = true;   
            App.Current.Shutdown();      
        }
    }
