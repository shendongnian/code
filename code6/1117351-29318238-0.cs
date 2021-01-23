    class RibbonSplitContainer : SplitContainer
    {
        private Color topGradientColor = Color.FromArgb(89, 135, 214);
        private Color bottomGradientColor = Color.FromArgb(0, 45, 150);
        private Color notchColor = Color.FromArgb(40, 50, 71);
        private Color notchShadowColor = Color.FromArgb(249, 249, 251);
        private Color notchTouchColor = Color.FromArgb(97, 116, 152);
        private ushort nbrNotches = 9;
        private int diff = 0;
        private bool drawBorderBottom = false;
        private bool drawBorderTop = false;
        private bool drawBorderLeft = false;
        private bool drawBorderRight = false;
        [DefaultValue(typeof(Color), "89,135,214")]
        [CategoryAttribute("Appearance")]
        public Color TopGradientColor
        {
            get { return topGradientColor; }
            set { topGradientColor = value; }
        }
        [DefaultValue(typeof(Color), "0,45,150")]
        public Color BottomGradientColor
        {
            get { return bottomGradientColor; }
            set { bottomGradientColor = value; }
        }
        [DefaultValue(typeof(Color), "40, 50, 71")]
        public Color NotchColor
        {
            get { return notchColor; }
            set { notchColor = value; }
        }
        [DefaultValue(typeof(Color), "249, 249, 251")]
        public Color NotchShadowColor
        {
            get { return notchShadowColor; }
            set { notchShadowColor = value; }
        }
        [DefaultValue(typeof(Color), "97, 116, 152")]
        public Color NotchTouchColor
        {
            get { return notchTouchColor; }
            set { notchTouchColor = value; }
        }
        [DefaultValue(9)]
        public ushort NbrNotches
        {
            get { return nbrNotches; }
            set { nbrNotches = value; }
        }
        [DefaultValue(false)]
        [CategoryAttribute("Appearance")]
        public bool DrawBorderBottom
        {
            get { return drawBorderBottom; }
            set { drawBorderBottom = value; }
        }
        [DefaultValue(false)]
        [CategoryAttribute("Appearance")]
        public bool DrawBorderTop
        {
            get { return drawBorderTop; }
            set { drawBorderTop = value; }
        }
        [DefaultValue(false)]
        [CategoryAttribute("Appearance")]
        public bool DrawBorderLeft
        {
            get { return drawBorderLeft; }
            set { drawBorderLeft = value; }
        }
        [DefaultValue(false)]
        [CategoryAttribute("Appearance")]
        public bool DrawBorderRight
        {
            get { return drawBorderRight; }
            set { drawBorderRight = value; }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Orientation == Orientation.Horizontal)
                {
                    int y = e.Y - diff;
                    if (y < 0) y = 0;
                    SplitterDistance = y;
                }
                else
                {
                    int x = e.X - diff;
                    if (x < 0) x = 0;
                    SplitterDistance = x;
                }
                Graphics g = CreateGraphics();
                Paint(g);
                g.Dispose();
                this.Panel1.Invalidate();
                this.Panel2.Invalidate();
                Update();
            }
            else base.OnMouseMove(e);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            //base.OnKeyDown(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //base.OnKeyPress(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (Orientation == Orientation.Horizontal)
            {
                diff = e.Y - this.Panel1.Height;
            }
            else
            {
                diff = e.X - this.Panel1.Width;
            }
        }
        protected new virtual void Paint(Graphics g)
        {
            Rectangle r = ClientRectangle;
            if (Orientation == Orientation.Horizontal)
            {
                r.Y = this.Panel1.Height;
                r.Height = this.SplitterWidth;
            }
            else
            {
                r.X = this.Panel1.Width;
                r.Width = this.SplitterWidth;
            }
            LinearGradientBrush brush = new LinearGradientBrush(r, topGradientColor,
                bottomGradientColor, (Orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal);
            g.FillRectangle(brush, r);
            Pen pen = new Pen(bottomGradientColor);
            if (Orientation == Orientation.Horizontal) g.DrawLine(pen, 0, r.Height, r.Width, r.Height);
            else g.DrawLine(pen, r.Width, 0, r.Width, r.Height);
            int startx;
            int starty;
            if (Orientation == Orientation.Horizontal)
            {
                startx = (Width - (4 * NbrNotches - 1)) / 2;
                starty = r.Y + 1;
            }
            else
            {
                startx = r.X + 2;
                starty = (Height - (4 * NbrNotches - 1)) / 2;
            }
            for (ushort i = 0; i < NbrNotches; i++)
            {
                pen.Color = notchColor;
                g.DrawPolygon(pen, new Point[] { new Point(startx, starty + 1), new Point(startx, starty), new Point(startx + 1, starty) });
                pen.Color = notchTouchColor;
                g.DrawLine(pen, startx + 1, starty + 1, startx + 2, starty + 1);
                pen.Color = notchShadowColor;
                g.DrawPolygon(pen, new Point[] { new Point(startx + 1, starty + 2), new Point(startx + 2, starty + 2), new Point(startx + 2, starty + 1) });
                if (Orientation == Orientation.Horizontal) startx += 4;
                else starty += 4;
            }
            brush.Dispose();
            pen.Dispose();
            if (drawBorderBottom)
            {
                g.DrawLine(Pens.Black, r.Left, r.Bottom-1, r.Right, r.Bottom-1);
            }
            if (drawBorderTop)
            {
                g.DrawLine(Pens.Black, r.Left, r.Top, r.Right, r.Top);
            }
            if (drawBorderLeft)
            {
                g.DrawLine(Pens.Black, r.Left, r.Top, r.Left, r.Bottom);
            }
            if (drawBorderRight)
            {
                g.DrawLine(Pens.Black, r.Right-1, r.Top, r.Right-1, r.Bottom);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Paint(g);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
        }
    }
