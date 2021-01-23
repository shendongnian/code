        protected void OnDrawItem(object sender, PaintEventArgs e)
        {
            Pen mPen = new Pen(bgColor, 10);
            Bitmap bmp = new Bitmap(10,10);
            Graphics g1 = Graphics.FromImage(bmp);
            g1.DrawRectangle(mPen, 0, 0, 10, 10);
            selectColorToolStripMenuItem.Image = bmp;
            
        }
