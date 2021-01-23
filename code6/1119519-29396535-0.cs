    pictureBox2.Parent = pictureBox1;
    pictureBox2.ImageLocation = potDoSlike;
    pictureBox2.Image = Image.FromFile(potDoSlike);
    Bitmap bmp = new Bitmap(pictureBox1.Image);
    pictureBox1.DrawToBitmap(bmp, pictureBox1.Bounds);
    pictureBox2.DrawToBitmap(bmp, pictureBox2.Bounds);
    bmp.Save(@"D:\asd.jpg");
