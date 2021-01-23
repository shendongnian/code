    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender.GetType().Name.Equals("StackPanel"))
            {
                XTextBlock.Text = "I am direct raised from StackPanel.";
            }
            else //sender.GetType().Name.Equals("Grid")
            {
                XTextBlock.Text += "I am bubble raised from Grid.";
            }
        }
    }
