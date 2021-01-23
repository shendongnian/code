    public new BorderStyle BorderStyle
    {
      get { return BorderStyle.Fixed3D; }
    }
    protected override void WndProc(ref Message m)
    {
      if (!DesignMode) {
        if (m.Msg == NativeMethods.WM_NCPAINT) {
          WmNcPaint(ref m);
          return;
        }
      }
      base.WndProc(ref m);
    }
    private void WmNcPaint(ref Message m)
    {
      if (!_HasBorders) {
        return;
      }
      IntPtr hDC = NativeMethods.GetWindowDC(m.HWnd);
      using (Graphics g = Graphics.FromHdc(hDC)) {
        // outer border
        g.DrawRectangle(new Pen(_BorderColor), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        // required since the border is 2px for Fixed3D (which is what TextBox uses by default)
        g.DrawRectangle(new Pen(BackColor), new Rectangle(1, 1, this.Width - 3, this.Height - 3));
      }
    }
