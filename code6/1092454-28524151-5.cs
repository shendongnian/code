    public class ImageItem
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public ImageSource Image { get; set; }
    }
    public class ViewModel
    {
        public ObservableCollection<ImageItem> ImageItems { get; set; }
    }
