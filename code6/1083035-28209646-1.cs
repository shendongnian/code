    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Rectangle rect = new Rectangle
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Fill = (Brush)FindResource("Alcanc"),
                Width = 200,
                Height = 150
            };
            canvas1.Children.Add(rect);
        }
    }
