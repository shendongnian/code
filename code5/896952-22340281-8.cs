    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    Bitmap bmpClone = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    Graphics objGraphics = Graphics.FromImage(bmpClone);
    objGraphics.DrawImage(pictureBox1.Image, 0, 0);
    objGraphics.Dispose();
    
    bmp = (Bitmap)bmpClone.Clone();
    pictureBox1.Image = bmp;
     
