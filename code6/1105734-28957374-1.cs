    public sealed partial class GraphicsPathForm : Form
    {
        private bool _graphicsPathIsVisible;
        private readonly Pen _pen = new Pen(Color.Red, 2);
        private readonly Brush _brush = new SolidBrush(Color.FromArgb(249, 214, 214));
        private readonly GraphicsPath _graphicsPath = new GraphicsPath();
        private Rectangle _rectangle = new Rectangle(10, 30, 100, 100);
        public GraphicsPathForm()
        {
            InitializeComponent();
            _graphicsPath.AddRectangle(_rectangle);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.Bilinear;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawPath(_pen, _graphicsPath);
            if (_graphicsPathIsVisible)
                g.FillPath(_brush, _graphicsPath);
            base.OnPaint(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            var isVisible = _graphicsPath.IsVisible(e.Location);
            if (isVisible == _graphicsPathIsVisible)
                return;
            const int zoom = 5;
            if (isVisible)
            {
                if (!_graphicsPathIsVisible)
                {
                    _rectangle.Inflate(zoom, zoom);
                    _graphicsPath.Reset();
                    _graphicsPath.AddRectangle(_rectangle);
                }
            }
            else
            {
                if (_graphicsPathIsVisible)
                {
                    _rectangle.Inflate(-zoom, -zoom);
                    _graphicsPath.Reset();
                    _graphicsPath.AddRectangle(_rectangle);
                }
            }
            _graphicsPathIsVisible = isVisible;
            Invalidate();
            base.OnMouseMove(e);
        }
    }
