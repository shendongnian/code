    public class Bitmap
    {
        public static implicit operator WriteableBitmap(Bitmap bitmap)
        {
            return bitmap._internalBitmap;
        }
        private readonly WriteableBitmap _internalBitmap;
        public Bitmap(int width, int height)
        {
            _internalBitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);
        }
    }
    public partial class MainWindow : Window
    {
        public Image XamlImage { get; set; }
        public MainWindow()
        {
            var bitmap = new Bitmap(100, 100);
            XamlImage.Source = bitmap;
        }
    }
