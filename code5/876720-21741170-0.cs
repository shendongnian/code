    Point originPoint = new Point(0,0);
    Rectangle rect = new Rectangle(originPoint, pictureBox.Image.Size);
    Bitmap bitImage = (Bitmap)pictureBox.Image;
    Bitmap formattedImage = bitImage.Clone(rect, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
    pictureBox.Image = formattedImage;
