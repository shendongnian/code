    using System.Windows.Forms.VisualStyles;
    protected override void OnPaint(PaintEventArgs e) {
      VisualStyleRenderer treeClose = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Closed);
      treeClose.DrawBackground(e.Graphics, new Rectangle(16, 16, 16, 16));
      TextRenderer.DrawText(e.Graphics, "Closed Branch", SystemFonts.DefaultFont, new Point(32, 16), Color.Black);
      VisualStyleRenderer treeOpen = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Opened);
      treeOpen.DrawBackground(e.Graphics, new Rectangle(16, 32, 16, 16));
      TextRenderer.DrawText(e.Graphics, "Opened Branch", SystemFonts.DefaultFont, new Point(32,32), Color.Black);
      base.OnPaint(e);
    }
