    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender.GetType().Name.Equals("StackPanel"))
            {
                XTextBlock.Text += ", I am tunneled raised from StackPanel.";
            }
            else //sender.GetType().Name.Equals("Grid")
            {
                XTextBlock.Text = "I am direct raised from Grid.";
            }
        }
    }
