    else
    {
        if (rects.Length > 0)
        {
            foreach (Rectangle objectRect in rects)
            {
                Graphics g = Graphics.FromImage(video);
                using (Pen pen = new Pen(Color.LightGreen, 3))
                {
                    g.DrawRectangle(pen, objectRect);
                    PointF drawPoin = new PointF(objectRect.X, objectRect.Y);
                    int objectX = objectRect.X + objectRect.Width / 2 - video.Width / 2;
                    int objectY = video.Height / 2 - (objectRect.Y + objectRect.Height / 2);
                    PointF drawPoin2 = new PointF(objectRect.X, objectRect.Y + objectRect.Height + 4);
                    String Blobinformation = "X= " + objectX.ToString() + "  Y= " + objectY.ToString() + "\nSize=" + objectRect.Width + ", " + objectRect.Height;
                    g.DrawString(Blobinformation, new Font("Arial", 12), new SolidBrush(Color.LightSkyBlue), drawPoin2);
                }
                g.Dispose();
            }
        }
    }
