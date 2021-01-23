    public partial class CloudBox : UserControl
    {
        public CloudBox()
        {
            InitializeComponent();
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw, true);
        }
        private readonly List<Ellipse> _clouds = new List<Ellipse>();
        public List<Ellipse> Clouds
        {
            get { return _clouds; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            foreach (var cloud in _clouds)
            {
                e.Graphics.FillEllipse(
                   cloud.Brush, cloud.Center.X, cloud.Center.Y,
                   cloud.Diameter, cloud.Diameter);
            }
            base.OnPaint(e);
        }
    }
