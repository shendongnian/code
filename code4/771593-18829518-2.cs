    Graphics g;
    private void picBox_MouseDown(object sender, MouseEventArgs e)
    {
        g = Graphics.FromImage(picBox.Image);
        draw = true;
        x = e.X;
        y = e.Y;
    }
    private void picBox_MouseMove(object sender, MouseEventArgs e)
    {
        if (draw)
        {
            // since you are using PictureBoxSizeMode.StretchImage:
            float rescaleX = (float)pixBox.Image.Width / pixBox.Width;
            float rescaleY = (float)pixBox.Image.Height / pixBox.Height;
            // if you do not want to produce a "trail" of shapes
            g.Clear(picBox.BackColor);
            switch (currItem)
            {
                case Item.Rectangle:
                    g.FillRectangle(new SolidBrush(paintColor), 
                              x * rescaleX, 
                              y * rescaleY, 
                              (e.X - x) * rescaleX, 
                              (e.Y - y) * rescaleY);
                    break;
                case Item.Ellipse:
                    g.FillEllipse(new SolidBrush(paintColor), 
                              x * rescaleX, 
                              y * rescaleY, 
                              (e.X - x) * rescaleX, 
                              (e.Y - y) * rescaleY);
                    break;           
            }
            picBox.Refresh();
        }
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        draw = false;
        lx = e.X;
        ly = e.Y;
        
        g.Dispose();
    }
