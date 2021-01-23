    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                PopupWindow.IsOpen = true;
                Point point = Mouse.GetPosition(Application.Current.MainWindow);
                PopupWindow.HorizontalOffset = point.X;
                PopupWindow.VerticalOffset = point.Y;
            }
        }
    }
