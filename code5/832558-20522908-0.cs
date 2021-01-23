    protected override void OnPaint(PaintEventArgs e) {
      e.Graphics.Clear(Color.White);
      Color textColor = Color.Red;
      if (this.Focused) {
        textColor = SystemColors.HighlightText;
        e.Graphics.FillRectangle(SystemBrushes.Highlight, 
                                 new Rectangle(4, 4, this.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 8, this.ClientSize.Height - 8));
      }
      TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, textColor, Color.Empty, TextFormatFlags.VerticalCenter);
      base.OnPaint(e);
    }
