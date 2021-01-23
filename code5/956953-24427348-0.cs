       private void CreateClipRectangle()
        {
            Rect srcRect = new Rect(PlateRectangle.X, PlateRectangle.Y, PlateRectangle.Width, PlateRectangle.Height);
            // We want to show some pixels outside the plate's rectangle, so add 60 to the PlateRectangle's Width.
            srcRect.Width += 60.0;
            // Adjust the Width property for the ZoomState, which increases the height & width of the rectangle around the license plate
            if (ZoomState == ZoomStates.ZoomPlus25)
            {
                srcRect.Width = srcRect.Width * 1.25;
            }
            else if (ZoomState == ZoomStates.ZoomPlus50)
            {
                srcRect.Width = srcRect.Width * 1.50;
            }
            // Make sure that srcRect.Width is not bigger than the ImageToBeZoomed's PixelWidth!
            if (srcRect.Width > ImageToBeZoomed.PixelWidth) srcRect.Width = ImageToBeZoomed.PixelWidth;
            // We need to keep the aspect ratio of the source rectangle the same as the Image's.
            // Compute srcRect.Height so the srcRect will have the correct aspect ratio, but don't let 
            // the rectangle's height get bigger than the original image's height!
            double aspectRatio = ((double)ImageToBeZoomed.PixelHeight / ImageToBeZoomed.PixelWidth); // <-- ADDED
            srcRect.Height = Math.Min(ImageToBeZoomed.PixelHeight, Math.Round(srcRect.Width * aspectRatio)); // <-- CHANGED
            // Adjust srcRect.X & srcRect.Y to center the source image in the output image
            srcRect.X = srcRect.X - srcRect.Width / 2.0; // <-- CHANGED
            srcRect.Y = srcRect.Y - srcRect.Height / 2.0; // <-- CHANGED
            // Adjust srcRect to keep the cropped region from going off the image's edges.
            if (srcRect.X < 0) srcRect.X = 0.0;
            if (srcRect.Y < 0) srcRect.Y = 0.0;
            if ((srcRect.X + srcRect.Width) > ImageToBeZoomed.PixelWidth) srcRect.X = ImageToBeZoomed.PixelWidth - srcRect.Width;
            if ((srcRect.Y + srcRect.Height) > ImageToBeZoomed.PixelHeight) srcRect.Y = ImageToBeZoomed.PixelHeight - srcRect.Height;
            double scaleX = (ImageControl.ActualWidth / ImageToBeZoomed.PixelWidth); // <-- ADDED
            double scaleY = (ImageControl.ActualHeight / ImageToBeZoomed.PixelHeight); // <-- ADDED
            srcRect.X *= scaleX; // <-- ADDED
            srcRect.Y *= scaleY; // <-- ADDED
            srcRect.Width *= scaleX; // <-- ADDED
            srcRect.Height *= scaleY; // <-- ADDED
            // Create a new RectangleGeometry object that we will use to clip the ImageToBeZoomed and put it into the Clip property.
            ImageControl.Clip = new RectangleGeometry(srcRect, 0.0, 0.0);
        }
