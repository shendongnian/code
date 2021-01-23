    public class Drawing
    {
        public Geometry Geometry { get; set; }
        public Brush Fill { get; set; }
        public Brush Stroke { get; set; }
        public double StrokeThickness { get; set; }
    }
    public class ViewModel
    {
        public ObservableCollection<Drawing> Drawings { get; set; }
    }
