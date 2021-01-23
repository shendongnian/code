        public Bitmap Rasterize()
        {
            Bitmap ringBmp = new Bitmap(width: _size.Width, height: _size.Height, format: PixelFormat.Format32bppArgb);
            //Create an appropriate region from the inscribed ellipse
            Drawing2D.GraphicsPath graphicsEllipsePath = new Drawing2D.GraphicsPath();
            graphicsEllipsePath.AddEllipse(0, 0, _size.Width, _size.Height);
            Region ellipseRegion = new Region(graphicsEllipsePath);
            //Create a graphics object from our new bitmap
            Graphics gfx = Graphics.FromImage(ringBmp);
            //Draw a resized version of our image to our new bitmap while using the highest quality interpolation and within the defined ellipse region
            gfx.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor;
            gfx.SmoothingMode = Drawing2D.SmoothingMode.HighQuality;
            gfx.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality;
            gfx.PageUnit = GraphicsUnit.Pixel;
            gfx.Clear(Color.Transparent);
            gfx.Clip = ellipseRegion;
            gfx.DrawImage(image: _image, rect: new Rectangle(0, 0, _size.Width, _size.Height));
            //Dispose our graphics
            gfx.Dispose();
            //return the resultant bitmap
            return ringBmp;
        }
