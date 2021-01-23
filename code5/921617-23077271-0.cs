    public class Zipfile
    {
        ...
        public ImageSource Image
        {
            get
            {
                Compressor.Unzip(this);
                var uri = string.Format("{0}{1}.jpg", Compressor.TempPath, this.ToString());
                return new BitmapImage(new Uri(uri));
            }
        }
    }
