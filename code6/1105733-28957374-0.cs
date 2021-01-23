    public sealed partial class GraphicsPathForm : Form
    {
        private bool _graphicsPathIsVisible;
        private readonly Pen _pen = new Pen(Color.Red, 2);
        private readonly Brush _brush = new SolidBrush(Color.FromArgb(249, 214, 214));
        private readonly GraphicsPath _graphicsPath = new GraphicsPath();
        public GraphicsPathForm()
        {
            InitializeComponent();
            _graphicsPath.AddRectangle(new Rectangle(10, 30, 100, 100));
            _graphicsPath.AddEllipse(new Rectangle(150, 80, 80, 40));
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
            var res = _graphicsPath.IsVisible(e.Location);
            if (res != _graphicsPathIsVisible)
            {
                _graphicsPathIsVisible = res;
                Invalidate();
            }
            base.OnMouseMove(e);
        }
    }
