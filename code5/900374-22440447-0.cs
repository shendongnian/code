    public partial class PathUserControl : UserControl
    {
        private readonly GraphicsPath path = new GraphicsPath();
        private float startAngle;
        private float sweepAngle = 90;
        private float innerPercent = 30;
        public PathUserControl()
        {
            base.BackColor = SystemColors.ControlDark;
        }
        [DefaultValue(0)]
        public float StartAngle
        {
            get { return startAngle; }
            set
            {
                startAngle = value;
                SetRegion();
            }
        }
        [DefaultValue(360)]
        public float SweepAngle
        {
            get { return sweepAngle; }
            set
            {
                sweepAngle = value;
                SetRegion();
            }
        }
        [DefaultValue(30)]
        public float InnerPercent
        {
            get { return innerPercent; }
            set
            {
                if (value < 0 || value > 100f)
                    throw new ArgumentOutOfRangeException("value", "Percent must be in the range 0 .. 100");
                innerPercent = value;
                SetRegion();
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (Region != null)
            {
                Region.Dispose();
                Region = null;
            }
            SetRegion();
        }
        private static PointF CreatePoint(double angle, double rx, double ry)
        {
            const double DEG_2_RAD = Math.PI / 180;
            return new PointF((float)(rx * Math.Sin(angle * DEG_2_RAD)), (float)(ry * Math.Cos(angle * DEG_2_RAD)));
        }
        private void SetRegion()
        {
            if (ClientSize.IsEmpty)
                return;
            float innerCoef = 0.01f * InnerPercent;
            float width = ClientSize.Width;
            float height = ClientSize.Height;
            float delta = SweepAngle / Math.Max(width, height);
            if (Math.Abs(delta) < 0.000001)
                return;
            List<PointF> tmp = new List<PointF>();
            tmp.Add(CreatePoint(StartAngle, width * innerCoef, height * innerCoef));
            for (float angle = 0; angle <= SweepAngle; angle += delta)
                tmp.Add(CreatePoint(StartAngle + angle, width, height));
            tmp.Add(CreatePoint(StartAngle + SweepAngle, width, height));
            for (float angle = 0; angle <= SweepAngle; angle += delta)
                tmp.Add(CreatePoint(StartAngle + SweepAngle - angle, width * innerCoef, height * innerCoef));
            path.Reset();
            path.AddLines(tmp.ToArray());
            path.CloseAllFigures();
            Region = new Region(path);
        }
    }
