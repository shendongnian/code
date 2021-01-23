    List<Point> PointsInCircleFast(int diameter)
    {
        List<Point> points = new List<Point>();
        Color black = Color.FromArgb(255, 0, 0, 0);
        using (Bitmap bmp = new Bitmap(diameter, diameter,PixelFormat.Format32bppArgb))
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.FillEllipse(Brushes.Black, 0, 0, diameter, diameter);
            }
            Size size0 = bmp.Size;
            Rectangle rect = new Rectangle(Point.Empty, size0);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
            int size1 = bmpData.Stride * bmpData.Height;
            byte[] data = new byte[size1];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, data, 0, size1);
             for (int y = 0; y < diameter; y++)
                 for (int x = 0; x < diameter; x++)
                 {
                     int index =  y * bmpData.Stride + x * 4;
                     if (data[index] == 0 ) points.Add(new Point(x, y));
                 }
        }
        return points;
    }
