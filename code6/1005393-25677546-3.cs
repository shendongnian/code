    public sealed class ChubosaurusCharts : Control
    {
        public ChubosaurusCharts()
        {
            this.DefaultStyleKey = typeof(ChubosaurusCharts);
        }
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
    
