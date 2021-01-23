    using (Graphics graphics = Graphics.FromImage(image))
        {
            Point p = new Point(0, 0);
            Point upperLeftSource = browser.PointToScreen(p);
            Point upperLeftDestination = new Point(0, 0);
    
            Size blockRegionSize = browser.ClientRectangle.Size;
            blockRegionSize.Width = blockRegionSize.Width - 15;
            blockRegionSize.Height = blockRegionSize.Height - 15;
            graphics.CopyFromScreen(upperLeftSource, upperLeftDestination, blockRegionSize);
        }
