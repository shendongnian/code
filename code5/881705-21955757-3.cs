    public class ImageItem
    {
        public string Source { get; set; }
        public double Left { get; set; }
        public double Top { get; set; }
    }
    public class ViewModel
    {
        public ViewModel()
        {
            ImageItems = new ObservableCollection<ImageItem>();
        }
        public ObservableCollection<ImageItem> ImageItems { get; private set; }
    }
