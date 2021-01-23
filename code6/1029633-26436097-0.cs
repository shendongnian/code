    private void doc_PrintPage(object sender, PrintPageEventArgs e)
    {
        float x = e.MarginBounds.Left;
        float y = e.MarginBounds.Top;
        Bitmap bmp = new Bitmap(panel2.Width, panel2.Height);
        panel2.DrawToBitmap(bmp, new Rectangle(0, 0, panel2.Width, panel2.Height));
        e.Graphics.DrawImage((Image)bmp, x, y);
    }
