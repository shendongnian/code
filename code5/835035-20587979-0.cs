    private void iiiimage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        Point point = e.GetPosition(iiiimage);
        ApplicationTitle.Text = point.ToString();
        var wb = new WriteableBitmap(iiiimage, null);
        int x, y;
        x = (int)(wb.PixelWidth * point.X / iiiimage.ActualWidth);
        y = (int)(wb.PixelHeight * point.Y / iiiimage.ActualHeight);
        int arrayPos = y * wb.PixelWidth + x;
        PageTitle.Text = String.Format("({0} ; {1}) --> {2}", x, y, arrayPos);
        int colorAsInt = wb.Pixels[arrayPos];
        Color c = Color.FromArgb((byte)((colorAsInt >> 0x18) & 0xff),
                            (byte)((colorAsInt >> 0x10) & 0xff),
                            (byte)((colorAsInt >> 8) & 0xff),
                            (byte)(colorAsInt & 0xff));
        r3ct.Fill = new SolidColorBrush(c);
    }
