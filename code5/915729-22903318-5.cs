    protected override void OnPaint(PaintEventArgs e)
    {
      Rectangle r = new Rectangle(0,0,this.ClientRectangle.Width-1,this.ClientRectangle.Height-1);
      e.Graphics.DrawRectangle(new Pen(Color.Gray, 1.0f), r);
    }
     
