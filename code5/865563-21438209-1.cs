    byte[] AoB = GetImage();
    using (MemoryStream ms = new MemoryStream(AoB)) {
        Image old = pictureBoxImage.Image;
        pictureBoxImage.Image = Image.FromStream(ms);
        old.Dispose();
    }
