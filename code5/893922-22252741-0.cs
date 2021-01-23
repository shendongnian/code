    var panel = new Panel() {
      BackColor = Color.White,
      MinimumSize = new Size(150, 72),
      Size = MinimumSize,     
    };
    panel.Paint += (s, e) => {
      TextRenderer.DrawText(e.Graphics, "Pop-up Panel",
      SystemFonts.DefaultFont, panel.ClientRectangle,
      Color.Black, Color.Empty,
      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    };
