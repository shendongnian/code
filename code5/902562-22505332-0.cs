    namespace WpfApplication
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext  = new Test
                    {
                        Data = new ObservableCollection<string> {"1", "2", "3"}
                    };
            }
        } 
    }
