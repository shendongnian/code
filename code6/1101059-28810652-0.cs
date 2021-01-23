    public class CropControl : UserControl 
    {
        public SelectionRect Selection
        {
            get { return (SelectionRect)GetValue(SelectionProperty); }
            set { SetValue(SelectionProperty, value); }
        }
        public static readonly DependencyProperty SelectionProperty =
            DependencyProperty.Register("Selection", typeof(SelectionRect), typeof(CropControl), new PropertyMetadata(null));
    }
    public class SelectionRect 
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
