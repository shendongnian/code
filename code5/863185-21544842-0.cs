    public void ResizeImage(string ImagePath, int width, int height, string newPath)
    {
        Bitmap b = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage((Image)b))
        {
            FileStream fs = new FileStream(ImagePath, FileMode.Open);
            Image img = Image.FromStream(fs);
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingMode = CompositingMode.SourceCopy;
            g.DrawImage(img, 0, 0, width, height);
            fs.Close();
        }
        b.Save(newPath);
        b.Dispose();
    }
