    pictureBox1.Invalidate();
    // create a new bitmap and create graphics from it
    var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
    var graphics = System.Drawing.Graphics.FromImage(bitmap);
    // draw on bitmap
    SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 255));
    System.Drawing.Rectangle rect = new System.Drawing.Rectangle(100,100, 50, 50);
    graphics.FillEllipse(semiTransBrush, rect);
    // set bitmap as the picturebox's image
    pictureBox1.Image = bitmap;
