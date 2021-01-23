    Graphics g = Graphics.FromImage(pictureBox1.Image);
    g.DrawLine(Pens.Yellow, 0,0, 600,600);
    
    using (Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height, g))
    {
        pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
        bmp.Save(@"C:\test.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
    }
