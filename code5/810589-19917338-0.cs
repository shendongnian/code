    public class Theme
    {
        public string Name { get; set; }
        public BitmapImage Image { get; set; }
        public Color Color { get; set; }
    
        public SolidColorBrush Brush
        {
            get
            {
                return new SolidColorBrush(Color);
            }
        }
    }
