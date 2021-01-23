    public class RectItem
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
    public class ViewModel
    {
        public ObservableCollection<RectItem> RectItems { get; set; }
    }
