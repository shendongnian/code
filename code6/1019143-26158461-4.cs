    private Color _BorderColor = SystemColors.WindowFrame;
    [Description("Color of the border")]
    [Category("Appearance")]
    public Color BorderColor
    {
      get { return _BorderColor; }
      set { _BorderColor = value; Invalidate(); }
    }
    private bool _HasBorders = false;
    [Description("Whether there should be any borders shown")]
    [Category("Appearance")]
    public bool HasBorders
    {
      get { return _HasBorders; }
      set { _HasBorders = value; Invalidate(); }
    }
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      if (_HasBorders) {
        ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, this.Width, this.Height), _BorderColor, ButtonBorderStyle.Solid);
      }
    }
    protected override void OnResize(EventArgs eventargs)
    {
      base.OnResize(eventargs);
      Refresh();
    }
