     public Image CaptureImage(bool showCursor, Size curSize, Point curPos, Point SourcePoint, Point DestinationPoint, Rectangle SelectionRectangle, string FilePath, string extension)
    {
        Bitmap bitmap = new Bitmap(SelectionRectangle.Width, SelectionRectangle.Height);
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            g.CopyFromScreen(SourcePoint, DestinationPoint, SelectionRectangle.Size);
            if (showCursor)
            {
                Rectangle cursorBounds = new Rectangle(curPos, curSize);
                Cursors.Default.Draw(g, cursorBounds);
            }
        }
        if (saveToClipboard)
        {
            Image img = (Image)bitmap;
            if (OnUpdateStatus == null) return bitmap;//<--- here
            ProgressEventArgs args = new ProgressEventArgs(img);
            OnUpdateStatus(this, args);
        }
        return bitmap;//<--- and here
     }
