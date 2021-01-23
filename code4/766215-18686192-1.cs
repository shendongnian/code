Code behind
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            FlatButton.Style = this.Resources["ExposedTile"] as Style;
            FlatButton.Background = Brushes.Orange;            
        }
    }
Output
