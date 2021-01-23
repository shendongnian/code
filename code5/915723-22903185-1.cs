    protected override void OnPaint(PaintEventArgs e)
    {
    	base.OnPaint(e);
    	Single fWidth = 5.0f;
    	Rectangle r = new Rectangle(0,0,this.ClientRectangle.Width-1,this.ClientRectangle.Height-1);
    	e.Graphics.DrawRectangle(new Pen(Color.Gray, fWidth), r);
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        this.Invalidate();
    }
