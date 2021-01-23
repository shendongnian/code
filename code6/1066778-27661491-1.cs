    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Dummy data
            DataContext = new
            {
                FileNames = Enumerable.Range(0, 5).Select(x => "File" + x.ToString())
            };
        }
    }
