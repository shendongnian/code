    public class StringModel :  INotifyPropertyChanged
    {
        public StringModel()
        {
        }
        public StringModel(
            Point topleft,
            string text,
            double fontsizediu,
            SolidColorBrush brush,
            double lineheight)
        {
            this.text = text;
            this.emSize = fontsizediu;
            this.color = brush;
            this.topleft = topleft;
            this.lineheight = lineheight;
        }
        public string text;
        public double emSize;
        public SolidColorBrush color;
        public Point topleft;
        public double? lineheight;
        private FormattedText _ft;
        public FormattedText ft
        {
            get
            {
                return _ft;
            }
            set
            {
                if (_ft != value)
                {
                    _ft = value;
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
