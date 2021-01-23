    public partial class MainWindow : Window
    {
        public InkCanvas_SandeepJadhav currCanvas = null;
        double width = 0, height = 0, toolWindowHeight = 0;
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;
            width = System.Windows.SystemParameters.WorkArea.Width;
            height = System.Windows.SystemParameters.WorkArea.Height;
            currCanvas = new InkCanvas_SandeepJadhav("Sandy");
            currCanvas.Width = width;
            currCanvas.Height = height - 150;
            currCanvas.Background = (System.Windows.Media.Brush)new SolidColorBrush(Colors.Lime);
            toolWindowHeight = (height / 10);
            currCanvas.Margin = new Thickness(0, 0, 0, toolWindowHeight);
            myGrid.Children.Add(currCanvas);
        }
    }
    
