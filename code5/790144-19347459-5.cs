    public ImageSource ImageSource { get; set; } // omitted OnPropertyChanged for brevity
    private ImageSource LoadImage(string path)
    {
        var bitmapImage = new BitmapImage();
        using (var stream = new FileStream(path, FileMode.Open))
        {
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
            bitmapImage.Freeze(); // optional
        }
        return bitmapImage;
    }
    ...
    ImageSource = LoadImage(@"C:\Users\Dave\Desktop\Duplicate\Swim.JPG");
