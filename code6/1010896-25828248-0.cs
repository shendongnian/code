    using(FileStream fs = new FileStream(@"C:\temp\pic.bmp", FileMode.Open, FileAccess.Read))
    {
        MemoryStream ms = new MemoryStream();
        fs.CopyTo(ms);
        ms.Seek(0, System.IO.SeekOrigin.Begin);
        bmp = (Bitmap)System.Drawing.Image.FromStream(ms);
    }
    pictureBox1.Image = bmp;
    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
    bmp2 = (Bitmap)bmp.Clone();
