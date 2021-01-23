    Bitmap b = new Bitmap(picture.Image);
    using (Graphics g = Graphics.FromImage(b)) {
        using (Bitmap drawnpic = new Bitmap(pathofpic)) {
            g.DrawImage(drawnpic, 0, 0, b.Width, b.Height);
        }
    }
    picture.Image = b;
