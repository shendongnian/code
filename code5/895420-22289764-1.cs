    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Enumerable.Range(0, 4).Select(x => "Item" + x.ToString());
        }
    }
