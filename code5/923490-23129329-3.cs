    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> PdfFiles { get; set; }
        public MainWindow()
        {
            PdfFiles = new List<string>();
            PdfFiles.Add("a");
            PdfFiles.Add("aa");
            PdfFiles.Add("aaa");
            InitializeComponent();
            DataContext = this;
        }
    }
