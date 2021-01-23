    Rectangle bounds = Screen.GetBounds(Cursor.Position);
    using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
    {
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
        }
        bitmap.Save("cap.png", ImageFormat.Png);
    }
