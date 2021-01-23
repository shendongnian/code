    byte[] AoB = GetImage();
    using (MemoryStream ms = new MemoryStream()) {
        ms.Write(AoB, 0, AoB.Length);
        Image old = pictureBoxImage.Image;
        pictureBoxImage.Image = Image.FromStream(ms);
        old.Dispose();
    }
