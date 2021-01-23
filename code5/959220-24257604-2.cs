    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = XDocument.Load("file://D:/ChangeLog.xml");
        }
    }
