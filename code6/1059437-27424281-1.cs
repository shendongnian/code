    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TestListView.ItemsSource = new[] {Severity.Severe, Severity.Alert, Severity.Warning};
        }
        enum Severity
        {
            Severe = 1,
            Warning = 2,
            Alert = 3,
            None = 4
        }
    }
