    public partial class PathUserControl : UserControl
    {
        private readonly GraphicsPath outerPath = new GraphicsPath();
        private readonly GraphicsPath innerPath = new GraphicsPath();
        private float startAngle;
        private float sweepAngle = 60;
        private float innerPercent = 30;
        public PathUserControl()
        {
            base.BackColor = SystemColors.ControlDark;
        }
        [DefaultValue(0)]
        [Description("The starting angle for the pie section, measured in degrees clockwise from the X-axis.")]
        public float StartAngle
        {
            get { return startAngle; }
            set
            {
                startAngle = value;
                SetRegion();
            }
        }
        [DefaultValue(60)]
        [Description("The angle between StartAngle and the end of the pie section, measured in degrees clockwise from the X-axis.")]
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
        [Description("Percent of the radius of the excluded inner area of the pie, measured from 0 to 100.")]
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
            SetRegion();
        }
        private void SetRegion()
        {
            if (Region != null)
            {
                Region.Dispose();
                Region = null;
            }
            if (ClientSize.IsEmpty)
                return;
            float innerCoef = 0.01f * InnerPercent;
            outerPath.Reset();
            innerPath.Reset();
            outerPath.AddPie(0, 0, ClientSize.Width, ClientSize.Height, StartAngle, SweepAngle);
            innerPath.AddPie(ClientSize.Width * (1 - innerCoef) / 2, ClientSize.Height * (1 - innerCoef) / 2, ClientSize.Width * innerCoef, ClientSize.Height * innerCoef, StartAngle, SweepAngle);
            Region region = new Region(outerPath);
            region.Xor(innerPath);
            Region = region;
        }
    }
