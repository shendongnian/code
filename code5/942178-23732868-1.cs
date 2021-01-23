    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDrag)
        {
            endPoint = new Point(e.X, e.Y);
            int maxLength = Math.Max(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
            currRect.Width = maxLength;
            currRect.Height = maxLength;
        }
    }
