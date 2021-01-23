    Image img = new Bitmap(300, 300);
    Graphics g = Graphics.FromImage(img);
    Font schriftart = new Font(StyleVerwaltung.Instance.Schriftart,
        StyleVerwaltung.Instance.SchriftgroesseDruckInfo);
    StringFormat format = new StringFormat();
    format.Alignment = StringAlignment.Center;
    _Report.Watermark.ImageAlign = ContentAlignment.BottomLeft;
    _Report.Watermark.ImageViewMode = ImageViewMode.Clip;
    g.SmoothingMode = SmoothingMode.AntiAlias;
    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
    g.TranslateTransform(0, g.VisibleClipBounds.Size.Height);
    g.RotateTransform(270f);
    g.DrawString(text, schriftart, Brushes.Black,
        new Rectangle(0, 0, (int)g.VisibleClipBounds.Size.Width,
                            (int)g.VisibleClipBounds.Height),
        format);
    g.ResetTransform();
    g.Flush();
    _Report.Watermark.Image = img;
    _Report.Watermark.ShowBehind = true;
