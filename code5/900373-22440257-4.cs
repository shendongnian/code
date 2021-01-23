    class ShapedControl : Control
    {
        private float startAngle;
        private float sweepAngle;
        private float innerRadius;
        private float outerRadius;
    
        public ShapedControl()
        {
            InnerRadius = 30;
            OuterRadius = 60;
            StartAngle = 0;
            SweepAngle = 360;
        }
    
        [DefaultValue(0)]
        [Description("The starting angle for the pie section, measured in degrees clockwise from the X-axis.")]
        public float StartAngle
        {
            get { return startAngle; }
            set
            {
                startAngle = value;
                Invalidate();
            }
        }
    
        [DefaultValue(360)]
        [Description("The angle between StartAngle and the end of the pie section, measured in degrees clockwise from the X-axis.")]
        public float SweepAngle
        {
            get { return sweepAngle; }
            set
            {
                sweepAngle = value;
                Invalidate();
            }
        }
    
        [DefaultValue(20)]
        [Description("Inner radius of the excluded inner area of the pie")]
        public float InnerRadius
        {
            get { return innerRadius; }
            set
            {
                innerRadius = value;
                Invalidate();
            }
        }
    
        [DefaultValue(30)]
        [Description("Outer radius of the pie")]
        public float OuterRadius
        {
            get { return outerRadius; }
            set
            {
                outerRadius = value;
                Invalidate();
            }
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
    
            Graphics g = e.Graphics;
            g.Clear(this.BackColor);
    
            GraphicsPath gp1 = new GraphicsPath();
            GraphicsPath gp2 = new GraphicsPath();
    
            float xInnerPos = -innerRadius / 2f + this.Width / 2f;
            float yInnerPos = -innerRadius / 2f + this.Height / 2f;
            float xOuterPos = -outerRadius / 2f + this.Width / 2f;
            float yOuterPos = -outerRadius / 2f + this.Height / 2f;
    
            if (innerRadius != 0.0)
                gp1.AddPie(xInnerPos, yInnerPos, innerRadius, innerRadius, startAngle, sweepAngle);
            gp2.AddPie(xOuterPos, yOuterPos, outerRadius, outerRadius, startAngle, sweepAngle);
    
            Region rg1 = new System.Drawing.Region(gp1);
            Region rg2 = new System.Drawing.Region(gp2);
    
            g.DrawPath(Pens.Transparent, gp1);
            g.DrawPath(Pens.Transparent, gp2);
    
            rg1.Xor(rg2);
    
            g.FillRegion(Brushes.Black, rg1);
    
            this.Region = rg1;
    
        }
    
        //Just for testing purpose. Place a breakpoint
        //in here and you'll see it will only get called when
        //you click inside the "pie" shape
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }
    }
