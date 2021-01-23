    private readonly List<Circle> circles = new List<Circle>();
    private Circle selectedCircle = null;
    protected override void OnMouseDown(MouseEventArgs e)
    {
        Circle hitCircle = circles.FirstOrDefault(x => x.Bounds.Contains(e.Location));
        if (hitCircle == null)
        {
            circles.Add(new Circle { Bounds = new Rectangle(e.Location, new Size(50, 50)) });
            this.Invalidate();
            selectedCircle = null;
        }
        else
        {
            selectedCircle = hitCircle;
        }
        base.OnMouseDown(e);
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (selectedCircle != null && e.Button == MouseButtons.Left)
        {
            selectedCircle.Move(e.Location);
            this.Invalidate();
        }
        base.OnMouseMove(e);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        foreach (var circle in circles)
        {
            e.Graphics.DrawEllipse(Pens.Black, circle.Bounds);
        }
        base.OnPaint(e);
    }
    public class Circle
    {
        public Rectangle Bounds { get; set; }
        public void Move(Point currentMousePoint)
        {
            Bounds = new Rectangle(currentMousePoint, Bounds.Size);
        }
    }
