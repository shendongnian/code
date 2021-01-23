    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var label = Template.FindName("lbl_title", this) as Label;
            Loaded += MainWindow_Loaded;
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var label = Template.FindName("lbl_title", this) as Label;
        }
    }
