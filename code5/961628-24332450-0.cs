    public class DotMockup
    {
        private SolidColorBrush _fill;
        private double _diameter;
        private Thickness _margin;
        public double Diameter
        {
            get { return _diameter; }
            set { _diameter = value; }
        }
        public SolidColorBrush Fill
        {
            get { return _fill; }
            set { _fill = value; }
        }
        public Thickness Margin
        {
            get { return _margin; }
            set { _margin = value; }
        }
    }
