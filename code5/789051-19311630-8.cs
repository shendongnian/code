    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pointEditor.Point = new Point2D{X = 300, Y = 400};
        }
    }
