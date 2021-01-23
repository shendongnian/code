    public class Ellipse
    {
        GraphicsPath gp = new GraphicsPath();
        RectangleF rect;
        public Ellipse(Point center, float rx, float ry)
        {
            Center = center;
            RadiusX = rx;
            RadiusY = ry;
            Visible = true;
            rect = new RectangleF(Center.X - RadiusX, Center.Y - RadiusY, RadiusX * 2, RadiusY * 2);
            gp.AddEllipse(rect);
            BackColor = Color.Green;
            BorderColor = Color.Transparent;
        }
        public event EventHandler Click;
        public event EventHandler MouseEnter;
        public event EventHandler MouseLeave;
        Point center;
        float rx, ry;
        Control canvas;
        bool entered;
        bool visible;
        Color backColor;
        Color borderColor;
        public bool Visible
        {
            get { return visible; }
            set
            {
                if (visible != value)
                {
                    visible = value;
                    if(canvas != null) canvas.Invalidate(Rectangle.Ceiling(rect));
                }
            }
        }
        public Control Canvas
        {
            get { return canvas; }
            set
            {
                if (canvas != value)
                {
                    canvas = value;
                    if (canvas != null)
                    {
                        AttachCanvas(canvas);
                        canvas.Invalidate(Rectangle.Ceiling(rect));
                    }                    
                }
            }
        }
        public Point Center
        {
            get { return center; }
            set
            {
                if (center != value)
                {
                    int dx = value.X - center.X;
                    int dy = value.Y - center.Y;
                    rect.Offset(dx, dy);
                    center = value;
                    gp.Reset();
                    gp.AddEllipse(rect);
                    if (canvas != null) canvas.Invalidate(Rectangle.Ceiling(rect));
                }
            }
        }
        public float RadiusX
        {
            get { return rx; }
            set
            {
                if (rx != value)
                {
                    rect.Width = rx * 2;
                    rx = value;
                    gp.Reset();
                    gp.AddEllipse(rect);
                    if (canvas != null) canvas.Invalidate(Rectangle.Ceiling(rect));
                }
            }
        }
        public float RadiusY
        {
            get { return ry; }
            set
            {
                if (ry != value)
                {
                    rect.Height = ry * 2;
                    ry = value;
                    gp.Reset();
                    gp.AddEllipse(rect);
                    if (canvas != null) canvas.Invalidate(Rectangle.Ceiling(rect));
                }
            }
        }
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                if (borderColor != value)
                {
                    borderColor = value;
                    if (canvas != null) canvas.Invalidate(Rectangle.Ceiling(rect));
                }
            }
        }
        public Color BackColor
        {
            get { return backColor; }
            set
            {
                if (backColor != value)
                {
                    backColor = value;
                    if (canvas != null) canvas.Invalidate(Rectangle.Ceiling(rect));
                }
            }
        }
        private void Render(Graphics g)
        {            
            using(Pen p = new Pen(BorderColor))
            using (Brush b = new SolidBrush(BackColor))
            {
                SmoothingMode sm = g.SmoothingMode;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillPath(b, gp);
                g.SmoothingMode = sm;
            }
        }
        private void AttachCanvas(Control canvas)
        {
            canvas.Paint += (s, e) =>
            {
               if(Visible) Render(e.Graphics);
            };
            canvas.MouseMove += (s, e) =>
            {
                var cv = s as Control;
                if (gp.IsVisible(e.Location))
                {
                    var handler = MouseEnter;
                    if (handler != null&&Visible) {
                        handler(this, EventArgs.Empty);                        
                    }
                    entered = true;
                }
                else if (entered)
                {
                    var handler = MouseLeave;
                    if (handler != null&&Visible){
                        handler(this, EventArgs.Empty);
                    }
                    entered = false;
                }
            };
            canvas.MouseClick += (s, e) =>
            {
                var cv = s as Control;
                if (gp.IsVisible(e.Location))
                {
                    var handler = Click;
                    if (handler != null&&Visible) handler(this, EventArgs.Empty);
                }
            };
        }
    }
