    public static void CalculateRatios(Panel panel, BitmapImage image, ref double horizontalShift, ref double verticalShift, ref double horizontalRatio, ref double verticalRatio)
        {
            panel.UpdateLayout();
            var ratioSource = image.PixelWidth / image.PixelHeight;
            var ratioImage = panel.ActualWidth / panel.ActualHeight;
            
            Size pictureInControlSize;
            
            if (ratioSource > ratioImage) // image control extended in height
            {
                pictureInControlSize = new Size(panel.ActualWidth, panel.ActualWidth / ratioSource);
            }
            else if (ratioSource < ratioImage) // image control extended in width
            {
                pictureInControlSize = new Size(panel.ActualHeight * ratioSource, panel.ActualHeight);
            }
            else // image control have the same proportions
            {
                pictureInControlSize = new Size(panel.ActualWidth, panel.ActualHeight);
            }
            horizontalShift = (panel.ActualWidth - pictureInControlSize.Width) / 2d;
            verticalShift = (panel.ActualHeight - pictureInControlSize.Height) / 2d;
            horizontalRatio = pictureInControlSize.Width / image.PixelWidth;
            verticalRatio = pictureInControlSize.Height / image.PixelHeight;
        }
