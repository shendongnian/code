    private void tabControl3_DrawItem(object sender, DrawItemEventArgs e)
    {
        Size xSize = new Size(16,16);
        Point imgLoc = new Point(e.Bounds.X +  4, e.Bounds.Y + 4);
        TabPage tp = tabControl3.TabPages[e.Index];
        e.DrawBackground();
        e.Graphics.DrawImage(imageList1.Images[tp.ImageIndex], new Rectangle(imgLoc, xSize), 
                                new Rectangle(Point.Empty, xSize), GraphicsUnit.Pixel);
        using (SolidBrush brush = new SolidBrush(e.ForeColor))
        {
            e.Graphics.DrawString(tp.Text + "   ", e.Font, brush, 
                                  e.Bounds.X + 23, e.Bounds.Y + 4);
            if (e.State == DrawItemState.Selected)
            {
                closeX = new Rectangle(e.Bounds.Right - xSize.Width - 3, 
                             e.Bounds.Top + 5, xSize.Width, xSize.Height);
                e.Graphics.DrawImage(imageList1.Images[0], closeX, 
                           new Rectangle(Point.Empty, xSize), GraphicsUnit.Pixel);
            }
        }
    }
