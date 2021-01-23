    public class ImageViewModel {
        public string Name { get; set; }
        public BitmapImage Bitmap{ get; set; }
        public string BitmapInfo { 
            get { 
                return string.Format("{0}x{1}", Bitmap.PixelWidth, Bitmap.PixelHeight);
            }
        }
        public bool CanBrowse { get; set; }
        // ...
    }
