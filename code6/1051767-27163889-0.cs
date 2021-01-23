    public class ImageClaz
    {
        public ImageClaz(Uri uri)
        {
            this.ImgArt = new BitmapImage(uri);
        }
        public ImageSource ImgArt { get; set; }
    }
