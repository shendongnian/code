    Bitmap newBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
    using (Graphics g = Graphics.FromImage(newBitmap)) {
      g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height), rectCropArea, GraphicsUnit.Pixel);
    }
    pictureBox2.Image = newBitmap;
