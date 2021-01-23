    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Items.ItemsSource = new List<int>(Enumerable.Range(0,100));
        }
    }
