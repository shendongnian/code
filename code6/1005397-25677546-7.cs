    public sealed class ChubosaurusCharts : Control
    {
        public ChubosaurusCharts()
        {
            this.DefaultStyleKey = typeof(ChubosaurusCharts);
            this.Surface = new Canvas();
        }
        private Canvas surface;
        public Canvas Surface
        {
            get
            {
                return surface;
            }
            set
            {
                surface = value;
            }
        }
    }
    
