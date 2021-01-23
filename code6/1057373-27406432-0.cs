    private void button2_Click(object sender, EventArgs e)
    {
        Bitmap bmp = new Bitmap(largePanel.ClientSize.Width, largePanel.ClientSize.Height);
        DrawToBitmap(largePanel, bmp);
        bmp.Save(yourFileName, System.Drawing.Imaging.ImageFormat.Png);
        bmp.Dispose();                      // get rid of the bog one!
        GC.Collect();                       // not sure why, but it helped
    }
    void DrawToBitmap(Control ctl, Bitmap bmp)
    {
        Cursor = Cursors.WaitCursor;         // yes it takes a while
        Panel p = new Panel();               // the containing panel
        Point oldLocation = ctl.Location;    // 
        p.Location = Point.Empty;            //
        this.Controls.Add(p);                //
        int maxWidth = 2000;                 // you may want to try othe sizes
        int maxHeight = 2000;                //
        Bitmap bmp2 = new Bitmap(maxWidth, maxHeight);  // the buffer
        p.Height = maxHeight;               // set up the..
        p.Width = maxWidth;                 // ..container
        ctl.Location = new Point(0, 0);     // starting point
        ctl.Parent = p;                     // inside the container
        p.Show();                           // 
        p.BringToFront();                   //
        // we'll draw onto the large bitmap with G
        using (Graphics G = Graphics.FromImage(bmp))
        for (int y = 0; y < ctl.Height; y += maxHeight)
        {
            ctl.Top = -y;                   // move up
            for (int x = 0; x < ctl.Width; x += maxWidth)
            {
                ctl.Left = -x;             // move left
                p.DrawToBitmap(bmp2, new Rectangle(0, 0, maxWidth, maxHeight));
                G.DrawImage(bmp2, x, y);   // patch together
            }
        }
        ctl.Location = p.Location;         // restore..
        ctl.Parent = this;                 // form layout
        p.Dispose();                       // clean up
        Cursor = Cursors.Default;          // done
    }
