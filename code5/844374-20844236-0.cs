    int h = 0;
    using (Graphics g = CreateGraphics()) {
      using (Font f = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)) {
        h = TextRenderer.MeasureText(msg, f, new Size(200, 0), 
                                     TextFormatFlags.WordBreak).Height;
      }
    }
