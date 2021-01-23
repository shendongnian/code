    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var bitmap = new WriteableBitmap(100, 100, 96, 96, PixelFormats.Indexed8, BitmapPalettes.Halftone256);
            int width = 50;
            int height = 50;
            var pixels = new byte[width*height];
            var random = new Random();
            random.NextBytes(pixels);
            bitmap.WritePixels(new Int32Rect(0, 0, width, height), pixels, width, 0);
            Image1.Source = bitmap;
        }
    }
