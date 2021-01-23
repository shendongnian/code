    Bitmap newImage = new Bitmap(_ctrlActiveControl.Width, _ctrlActiveControl.Height);
    using (Bitmap bm = new Bitmap(_ctrlActiveControl.Image))
    {
        using (Graphics g = Graphics.FromImage(newImage))
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Point[] corners = { new Point(0, 0), new Point(newImage.Width, 0), new Point(0, newImage.Height) };
            g.DrawImage(bm, corners);
        }
    }
    _ctrlActiveControl.Image = newImage;
