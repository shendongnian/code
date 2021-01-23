    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.NamedColors = this.GetColors();
            this.DataContext = this;
        }
        public IEnumerable<KeyValuePair<String, Color>> NamedColors
        {
            get;
            private set;
        }
    }
