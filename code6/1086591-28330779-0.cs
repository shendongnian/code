    void doc_PrintPage(object sender, PrintPageEventArgs e) {
      using (Bitmap bmp = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height)) {
        panel1.DrawToBitmap(bmp, panel1.ClientRectangle);
        RectangleF bounds = e.PageSettings.PrintableArea;
        float factor = ((float)bmp.Height / (float)bmp.Width);
        e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top,
                                  bounds.Width, factor * bounds.Width);
      }
    }
