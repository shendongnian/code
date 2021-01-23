    private void pbImage_Paint(object sender, PaintEventArgs e)
    {
        base.Paint(); // Paints the image
        if (this.rdFront.Checked)
            RenderFront(e.Graphics, true);
        else
            RenderBack(e.Graphics, true);
    }
    public void RenderFront(Graphics g, bool includeBoxes)
    {
        foreach (MessageConfiguration config in this.config.Values.Where(c => c.Front)) {
            if (includeBoxes) {
                g.FillRectangle(Brushes.White, config.X, config.Y, config.Width, config.Height);
                g.DrawRectangle(Pens.Black, config.X - 1, config.Y - 1, config.Width + 2, config.Height + 2);
            }
            g.DrawString(config.Text, new Font(FontFamily.GenericMonospace, config.FontSize), Brushes.Black, new PointF(config.X, config.Y));
        }
    }
