    public class Ellipse : IDisposable
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
            SelectedBackColor = Color.LimeGreen;
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
        Color selectedColor;
        bool selected;
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected != value)
                {
                    selected = value;
                    if (canvas != null) canvas.Invalidate(Rectangle.Ceiling(rect));
                }
            }
        }
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
                    if(canvas != null) DetachCanvas(canvas);
                    if (value != null)
                    {
                        AttachCanvas(value);
                        value.Invalidate(Rectangle.Ceiling(rect));
                    }                    
                    canvas = value;
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
        public Color SelectedBackColor
        {
            get { return selectedColor; }
            set
            {
                if (selectedColor != value)
                {
                    selectedColor = value;
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
            using (Brush b = new SolidBrush(selected ? SelectedBackColor : BackColor))
            {
                SmoothingMode sm = g.SmoothingMode;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillPath(b, gp);
                g.DrawPath(p, gp);
                g.SmoothingMode = sm;
            }
        }
        private void CanvasPaint(object sender, PaintEventArgs e)
        {
            if (Visible) Render(e.Graphics);
        }
        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            var cv = sender as Control;
            if (gp.IsVisible(e.Location))
            {
                var handler = MouseEnter;
                if (handler != null && Visible)
                {
                    handler(this, EventArgs.Empty);
                }
                entered = true;
            }
            else if (entered)
            {
                var handler = MouseLeave;
                if (handler != null && Visible)
                {
                    handler(this, EventArgs.Empty);
                }
                entered = false;
            }
        }
        private void CanvasMouseClick(object sender, MouseEventArgs e){
            var cv = sender as Control;
            if (gp.IsVisible(e.Location))
            {
                var handler = Click;                
                if (handler != null && Visible) handler(this, EventArgs.Empty);
            }
        }
        private void AttachCanvas(Control canvas)
        {
            canvas.Paint += CanvasPaint;
            canvas.MouseMove += CanvasMouseMove;
            canvas.MouseClick += CanvasMouseClick;
        }
        private void DetachCanvas(Control canvas)
        {
            canvas.Paint -= CanvasPaint;
            canvas.MouseMove -= CanvasMouseMove;
            canvas.MouseClick -= CanvasMouseClick;
        }
        
        public void Dispose()
        {
            Visible = false;
            if (Canvas != null) Canvas.Invalidate(Rectangle.Ceiling(rect));
            Canvas = null;
            gp.Dispose();             
        }        
    }
