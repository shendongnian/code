    public Point GetPixelPosition(Color SearchColor, bool IgnoreAlphaChannel, int pixelsToSearchAround)
        {
            Point mousePosition = Cursor.Position;
            _ColorFound = false;
            Point PixelPt = new Point(0, 0);
            using (Bitmap b = CaptureScreen())
            {
                int minX = mousePosition.X - pixelsToSearchAround;
                int maxX = mousePosition.X + pixelsToSearchAround;
                int minY = mousePosition.Y - pixelsToSearchAround;
                int maxY = mousePosition.Y + pixelsToSearchAround;
                if(minX < 0) minX = 0;
                if(minY < 0) minY = 0;
                if(maxX > b.Width) maxX = b.Width;
                if(maxY > b.Height) maxY = b.Height;
    
                for (int i = minX; i < maxX; i++)
                {
                    if (this._ColorFound)
                        break;
                    for (int j = minY; j < maxY; j++)
                    {
                        if (this._ColorFound)
                            break;
                        Color tmpPixelColor = b.GetPixel(i, j);
                        if (((tmpPixelColor.A == SearchColor.A) || IgnoreAlphaChannel)
                            && (tmpPixelColor.R == SearchColor.R)
                            && (tmpPixelColor.G == SearchColor.G)
                            && (tmpPixelColor.B == SearchColor.B)
                            )
                        {
                            PixelPt.X = i;
                            PixelPt.Y = j;
                            this._ColorFound = true;
                        }
                    }
                }
            }
            return PixelPt;
        }
