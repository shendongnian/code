    Point mouseLocation;
    public GraphicContainer(Control control, string text, int left, int top)
        : base(control, text, left, top, 400, 200) {
        //prevents flickering
        this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        //subscribes to mousemove
        this.MouseMove += (obj,e) => {
            //only when left mousebutton is pressed
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //update the location
                mouseLocation = e.Location;
                //invalidate the control
                this.Invalidate();
            }
        };
    }
    protected override void OnPaint(PaintEventArgs pe)
    {
        // Call the OnPaint method of the base class.
        base.OnPaint(pe);
    
        // Declare and instantiate a new pen.
        Pen pen = new Pen(Color.Fuchsia, 15);
        SolidBrush myBrush = new System.Drawing.SolidBrush(Color.HotPink);
        // Draw an aqua rectangle in the rectangle represented by the control.
        Rectangle blublublu = new Rectangle(mouseLocation, this.Size - new Size(25, 25));
            pe.Graphics.DrawRectangle(pen, blublublu);
        pe.Graphics.FillRectangle(myBrush, blublublu);
    }
    
    protected override void OnMouseMove(MouseEventArgs e)
    {
        //nothing here
    }
