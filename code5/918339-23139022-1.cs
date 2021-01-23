    protected override void OnPaintBackground(PaintEventArgs e) {
        base.OnPaintBackground(e);
        var captionHeight = SystemInformation.CaptionHeight;
        int border = SystemInformation.Border3DSize.Width;
        var color1 = Color.FromKnownColor(activated ? KnownColor.ActiveCaption : KnownColor.InactiveCaption);
        var color2 = Color.FromKnownColor(activated ? KnownColor.GradientActiveCaption : KnownColor.GradientInactiveCaption);
        var captionrc = new Rectangle(0, 0, this.ClientSize.Width, captionHeight);
        using (var brush = new LinearGradientBrush(captionrc, color1, color2, 0, false)) {
            e.Graphics.FillRectangle(brush, captionrc);
        }
        int textx = border;
        if (this.Icon != null) {
            int height = SystemInformation.SmallIconSize.Height;
            var iconrc = new Rectangle(border, (captionHeight - height)/2, height, height);
            textx += height + border;
            e.Graphics.DrawIcon(this.Icon, iconrc);
        }
        var color = Color.FromKnownColor(activated ? KnownColor.ActiveCaptionText : KnownColor.InactiveCaptionText);
        using (var font = new Font(this.Font.FontFamily, SystemInformation.CaptionHeight - 4 * border, GraphicsUnit.Pixel)) {
            TextRenderer.DrawText(e.Graphics, this.Text, font, new Point(textx, border), color);
        }
        using (var font = new Font(new FontFamily("Webdings"), captionHeight - 4 * border, GraphicsUnit.Pixel)) {
            var glyphs = this.WindowState == FormWindowState.Maximized ? "\u0030\u0031\u0072" : "\u0030\u0031\u0072";
            var width = TextRenderer.MeasureText(glyphs, font).Width;
            TextRenderer.DrawText(e.Graphics, glyphs, font, 
                new Point(this.ClientSize.Width - width, border),
                Color.FromKnownColor(KnownColor.WindowFrame));
        }
    }
