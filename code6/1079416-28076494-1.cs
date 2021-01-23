    [ImplementPropertyChanged]
    public partial class MainWindow : Window
    {
        public bool FirstTabSelected { get; set; }
        public bool SecondTabSelected { get; set; }
        public MainWindow()
        {
            FirstTabSelected = true;
            SecondTabSelected = true;
            InitializeComponent();
            this.DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FirstTabSelected = !FirstTabSelected;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SecondTabSelected = !SecondTabSelected;
        }
    }
