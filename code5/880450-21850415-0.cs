    Point mouseLocation;
    public GraphicContainer(Control control, string text, int left, int top)
        : base(control, text, left, top, 400, 200) {
        this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }
    protected override void OnPaint(PaintEventArgs pe)
    {
        // Call the OnPaint method of the base class.
        base.OnPaint(pe);
    
        // Declare and instantiate a new pen.
        Pen pen = new Pen(Color.Fuchsia, 15);
        SolidBrush myBrush = new System.Drawing.SolidBrush(Color.HotPink);
        // Draw an aqua rectangle in the rectangle represented by the control.
        //pe.Graphics.DrawRectangle(pen, new Rectangle(this.Location,this.Size));
        Rectangle blublublu = new Rectangle(mouseLocation, this.Size - new Size(25, 25));
            pe.Graphics.DrawRectangle(pen, blublublu);
        pe.Graphics.FillRectangle(myBrush, blublublu);
    }
    
    protected override void OnMouseMove(MouseEventArgs e)
    {
        mouseLocation = e.Location;
        this.Invalidate();
    }
