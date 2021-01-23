    Rectangle rectCropArea = new Rectangle(0, 0, 100, 100);
    Bitmap destBitmap = new Bitmap(pictureBox2.Width, pictureBox2.Height);
    Graphics g = Graphics.FromImage(destBitmap);
    g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height), rectCropArea, GraphicsUnit.Pixel);
    g.Dispose();
    pictureBox2.Image = destBitmap;
    pictureBox2.Image.Save(@"c:\temp\patch1.jpg");
