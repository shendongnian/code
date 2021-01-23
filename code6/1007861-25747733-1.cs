    public void RefreshImage()
    {
        Bitmap bmp;
        if (this.rdFront.Checked)
            bmp = new Bitmap(front);
        else
            bmp = new Bitmap(back);
        using (Graphics gfx = Graphics.FromImage(bmp)) {
            foreach (MessageConfiguration config in this.config.Values.Where(c => c.Front))
            {
                if (includeBoxes) {
                    // Fill a White rectangle and then surround with a black border
                    gfx.FillRectangle(Brushes.White, config.X, config.Y, config.Width, config.Height);
                    gfx.DrawRectangle(Pens.Black, config.X - 1, config.Y - 1, config.Width + 2, config.Height + 2);
                }
                gfx.DrawString(config.Text, new Font(FontFamily.GenericMonospace, config.FontSize), Brushes.Black, new PointF(config.X, config.Y));
            }
        }
        pbImage.Image = bmp;
    }
