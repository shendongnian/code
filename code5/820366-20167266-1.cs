    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                RadioButton rb = new RadioButton();
                rb.Content = "Item " + i.ToString();
                rb.Click += rb_Click;
                StackPanel.Children.Add(rb);
            }
        }
        void rb_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((sender as RadioButton).Content.ToString());
        }
    }
