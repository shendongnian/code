    public struct ImageData
    {
        /// <summary>
        /// Intensity map
        /// </summary>
        int[,] intensities;
        /// <summary>
        /// Pixel dimensios of image like 1360 × 1024
        /// </summary>
        Size pixel_size;
        
        /// <summary>
        /// Physical dimensions like 300μ × 260μ
        /// </summary>
        SizeF actual_size;
        /// <summary>
        /// Transforms pixel coordinates to actual dimensions. Assumes center of image is (0,0)
        /// </summary>
        /// <param name="pixel">The pixel coordinates (integer i,j)</param>
        /// <rereturns>The physical coordinates (float x,y)</rereturns>
        public PointF PixelToPoint(Point pixel)
        {
            return new PointF(
                actual_size.Width*((float)pixel.X/(pixel_size.Width-1)-0.5f),
                actual_size.Height*((float)pixel.Y/(pixel_size.Height-1)-0.5f));
        }
        /// <summary>
        /// Transforms actual dimensions to pixels. Assumes center of image is (0,0)
        /// </summary>
        /// <param name="point">The point coordines (float x,y)</param>
        /// <returns>The pixel coordinates (integer i,j)</returns>
        public Point PointToPixel(PointF point)
        {
            return new Point(
                (int)((pixel_size.Width-1)*(point.X/actual_size.Width+0.5f)),
                (int)((pixel_size.Height-1)*(point.Y/actual_size.Height+0.5f)));
        }
        /// <summary>
        /// Get the ratio of intensities included inside the strip (yellow lines). 
        /// Assume beam is located at the center.
        /// </summary>
        /// <param name="strip_width">The strip width in physical dimensions</param>
        /// <param name="strip_angle">The strip angle in degrees</param>
        /// <returns></returns>
        public float GetRatio(float strip_width, float strip_angle)
        {
            // Convert degrees to radians
            strip_angle*=(float)(Math.PI/180);
            // Cache sin() and cos()
            float cos=(float)Math.Cos(strip_angle), sin=(float)Math.Sin(strip_angle);
            //line through (xc,yc) with angle ψ is  (y-yc)*COS(ψ)-(x-xc)*SIN(ψ)=0
            //to offset the line by amount d, by add/subtract d from the equation above
            float inside=0, all=0;
            for(int i=0; i<pixel_size.Width; i++)
            {
                for(int j=0; j<pixel_size.Height; j++)
                {
                    Point pixel=new Point(i, j);
                    //find distance to strip center line
                    PointF point=PixelToPoint(pixel);
                    float t=-sin*point.X+cos*pixel.Y;
                    if(Math.Abs(t)<=strip_width/2)
                    {
                        inside+=intensities[i, j];
                    }
                    all += intensities[i,j];
                }
            }
            return inside/all;
        }
    }
