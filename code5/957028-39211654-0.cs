    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Loaded += (s, e) => SetMaxWindowSize();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }
        private void SetMaxWindowSize()
        {
            System.Drawing.Rectangle rec = System.Windows.Forms.Screen.FromHandle(new System.Windows.Interop.WindowInteropHelper(this).Handle).WorkingArea;
            MaxHeight = rec.Height;
            MaxWidth = rec.Width;
        }
    }
