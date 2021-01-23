    protected override void OnPaint(PaintEventArgs e)
    {
      // ...paint the control here...
      if (_HasBorder) {
        e.Graphics.DrawRectangle(new Pen(_BorderColor), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
      }
      base.OnPaint(e);
    }
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      Refresh();
    }
