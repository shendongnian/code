    protected override void WndProc(ref Message m)
    {
      base.WndProc(ref m);
      if (m.Msg == NativeMethods.WM_PAINT) {
        OnWmPaint();
      }
    }
    private void OnWmPaint()
    {
      using (Graphics g = CreateGraphics()) {
        if (!_HasBorders) {
          g.DrawRectangle(new Pen(BackColor), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
          return;
        }
        if (!Enabled) {
          g.DrawRectangle(new Pen(_BorderColorDisabled), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
          return;
        }
        if (ContainsFocus) {
          g.DrawRectangle(new Pen(_BorderColorActive), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
          return;
        }
        g.DrawRectangle(new Pen(_BorderColor), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
      }
    }
