    double zoomFactorX = picturBox1.Width / mRect.Width;
    double zoomFactorY = picturBox1.Height / mRect.Height;
    Size newSize;
    Point newLocation;
    if (zoomFactorX < zoomFactorY) { // Fit image portion horizontally.
        newSize = new Size(picturBox1.Width, (int)Math.Round(zoomFactorX * mRect.Height));
        // We have a top and a bottom padding.
        newLocation = new Point(0, (picturBox1.Height - newSize.Height) / 2);
    } else {  // Fit image portion vertically.
        newSize = new Size((int)Math.Round(zoomFactorY * mRect.Width), picturBox1.Height);
 
        // We have a left and a right padding.
       newLocation = new Point((picturBox1.Width - newSize.Width) / 2, 0);
    }
