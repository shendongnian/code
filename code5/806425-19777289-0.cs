    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var someSong = new Song(...);
            this.DataContext = someSong;
            InitializeComponent();
        }
    }
