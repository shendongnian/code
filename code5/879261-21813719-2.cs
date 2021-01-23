        Bitmap bit = new Bitmap(open.FileName);
        Bitmap bitNew = new Bitmap(bit);
        bit.Dispose();
        pictureBox1.Image = bmpNew;
        pictureBox1.Image.Save(@"frame.jpeg", ImageFormat.Jpeg);
        bitNew.Dispose();
