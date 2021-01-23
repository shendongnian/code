    public Image ProcessImage(ImageFactory factory)
    {
        Bitmap cyan = null;
        Bitmap magenta = null;
        Bitmap yellow = null;
        Bitmap keyline = null;
        Bitmap newImage = null;
        Image image = factory.Image;
        try
        {
            int width = image.Width;
            int height = image.Height;
            // Angles taken from Wikipedia page.
            float cyanAngle = 15f;
            float magentaAngle = 75f;
            float yellowAngle = 0f;
            float keylineAngle = 45f;
            int diameter = 4;
            float multiplier = 4 * (float)Math.Sqrt(2);
            // Cyan color sampled from Wikipedia page.
            Brush cyanBrush = new SolidBrush(Color.FromArgb(0, 153, 239));
            Brush magentaBrush = Brushes.Magenta;
            Brush yellowBrush = Brushes.Yellow;
            Brush keylineBrush;
            // Create our images.
            cyan = new Bitmap(width, height);
            magenta = new Bitmap(width, height);
            yellow = new Bitmap(width, height);
            keyline = new Bitmap(width, height);
            newImage = new Bitmap(width, height);
            // Ensure the correct resolution is set.
            cyan.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            magenta.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            yellow.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            keyline.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            newImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            // Check bounds against this.
            Rectangle rectangle = new Rectangle(0, 0, width, height);
            using (Graphics graphicsCyan = Graphics.FromImage(cyan))
            using (Graphics graphicsMagenta = Graphics.FromImage(magenta))
            using (Graphics graphicsYellow = Graphics.FromImage(yellow))
            using (Graphics graphicsKeyline = Graphics.FromImage(keyline))
            {
                // Ensure cleared out.
                graphicsCyan.Clear(Color.Transparent);
                graphicsMagenta.Clear(Color.Transparent);
                graphicsYellow.Clear(Color.Transparent);
                graphicsKeyline.Clear(Color.Transparent);
                // This is too slow. The graphics object can't be called within a parallel 
                // loop so we have to do it old school. :(
                using (FastBitmap sourceBitmap = new FastBitmap(image))
                {
                    for (int y = -height * 2; y < height * 2; y += diameter)
                    {
                        for (int x = -width * 2; x < width * 2; x += diameter)
                        {
                            Color color;
                            CmykColor cmykColor;
                            float brushWidth;
                            // Cyan
                            Point rotatedPoint = RotatePoint(new Point(x, y), new Point(0, 0), cyanAngle);
                            int angledX = rotatedPoint.X;
                            int angledY = rotatedPoint.Y;
                            if (rectangle.Contains(new Point(angledX, angledY)))
                            {
                                color = sourceBitmap.GetPixel(angledX, angledY);
                                cmykColor = color;
                                brushWidth = diameter * (cmykColor.C / 255f) * multiplier;
                                graphicsCyan.FillEllipse(cyanBrush, angledX, angledY, brushWidth, brushWidth);
                            }
                            // Magenta
                            rotatedPoint = RotatePoint(new Point(x, y), new Point(0, 0), magentaAngle);
                            angledX = rotatedPoint.X;
                            angledY = rotatedPoint.Y;
                            if (rectangle.Contains(new Point(angledX, angledY)))
                            {
                                color = sourceBitmap.GetPixel(angledX, angledY);
                                cmykColor = color;
                                brushWidth = diameter * (cmykColor.M / 255f) * multiplier;
                                graphicsMagenta.FillEllipse(magentaBrush, angledX, angledY, brushWidth, brushWidth);
                            }
                            // Yellow
                            rotatedPoint = RotatePoint(new Point(x, y), new Point(0, 0), yellowAngle);
                            angledX = rotatedPoint.X;
                            angledY = rotatedPoint.Y;
                            if (rectangle.Contains(new Point(angledX, angledY)))
                            {
                                color = sourceBitmap.GetPixel(angledX, angledY);
                                cmykColor = color;
                                brushWidth = diameter * (cmykColor.Y / 255f) * multiplier;
                                graphicsYellow.FillEllipse(yellowBrush, angledX, angledY, brushWidth, brushWidth);
                            }
                            // Keyline 
                            rotatedPoint = RotatePoint(new Point(x, y), new Point(0, 0), keylineAngle);
                            angledX = rotatedPoint.X;
                            angledY = rotatedPoint.Y;
                            if (rectangle.Contains(new Point(angledX, angledY)))
                            {
                                color = sourceBitmap.GetPixel(angledX, angledY);
                                cmykColor = color;
                                brushWidth = diameter * (cmykColor.K / 255f) * multiplier;
                                // Just using blck is too dark. 
                                keylineBrush = new SolidBrush(CmykColor.FromCmykColor(0, 0, 0, cmykColor.K));
                                graphicsKeyline.FillEllipse(keylineBrush, angledX, angledY, brushWidth, brushWidth);
                            }
                        }
                    }
                }
                // Set our white background.
                using (Graphics graphics = Graphics.FromImage(newImage))
                {
                    graphics.Clear(Color.White);
                }
                // Blend the colors now to mimic adaptive blending.
                using (FastBitmap cyanBitmap = new FastBitmap(cyan))
                using (FastBitmap magentaBitmap = new FastBitmap(magenta))
                using (FastBitmap yellowBitmap = new FastBitmap(yellow))
                using (FastBitmap keylineBitmap = new FastBitmap(keyline))
                using (FastBitmap destinationBitmap = new FastBitmap(newImage))
                {
                    Parallel.For(
                        0,
                        height,
                        y =>
                        {
                            for (int x = 0; x < width; x++)
                            {
                                // ReSharper disable AccessToDisposedClosure
                                Color cyanPixel = cyanBitmap.GetPixel(x, y);
                                Color magentaPixel = magentaBitmap.GetPixel(x, y);
                                Color yellowPixel = yellowBitmap.GetPixel(x, y);
                                Color keylinePixel = keylineBitmap.GetPixel(x, y);
                                CmykColor blended = cyanPixel.AddAsCmykColor(magentaPixel, yellowPixel, keylinePixel);
                                destinationBitmap.SetPixel(x, y, blended);
                                // ReSharper restore AccessToDisposedClosure
                            }
                        });
                }
            }
            cyan.Dispose();
            magenta.Dispose();
            yellow.Dispose();
            keyline.Dispose();
            image.Dispose();
            image = newImage;
        }
        catch (Exception ex)
        {
            if (cyan != null)
            {
                cyan.Dispose();
            }
            if (magenta != null)
            {
                magenta.Dispose();
            }
            if (yellow != null)
            {
                yellow.Dispose();
            }
            if (keyline != null)
            {
                keyline.Dispose();
            }
            if (newImage != null)
            {
                newImage.Dispose();
            }
            throw new ImageProcessingException("Error processing image with " + this.GetType().Name, ex);
        }
        return image;
    } 
