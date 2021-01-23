    class EmptySpace : Space
    {
        private static readonly EmptySpace instance = new EmptySpace();
        public static EmptySpace Instance
        {
            get { return instance; }
        }
        private static readonly SolidBrush brush = new SolidBrush(Color.DeepPink);
        public SolidBrush Brush { get { return brush; } }
        private EmptySpace() { }
    }
