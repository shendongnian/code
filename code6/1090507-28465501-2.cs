    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            UpdateImage = ImageHelpers.ConvertBitmapToImageSource(...);
            DeleteImage = ImageHelpers.ConvertBitmapToImageSource(...);
            InitializeComponent();
        }
        public ImageSource UpdateImage { get; set; }
        public ImageSource DeleteImage { get; set; }
    }
