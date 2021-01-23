    public partial class MainWindow : Window
        {
    
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DllstringTest st = new DllstringTest();
            st.testString = "5";
            Window1 w1 = new Window1(st);
            w1.Show();
        }
    }
    }
