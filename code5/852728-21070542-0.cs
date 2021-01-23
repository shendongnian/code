        private static Bitmap RotateImage(Image b, float angle)
        {
            var corners = new[]
                {new PointF(0, 0), new Point(b.Width, 0), new PointF(0, b.Height), new PointF(b.Width, b.Height)};
            var xc = corners.Select(p => Rotate(p, angle).X);
            var yc = corners.Select(p => Rotate(p, angle).Y);
        
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap((int)Math.Abs(xc.Max() - xc.Min()), (int)Math.Abs(yc.Max() - yc.Min()));
            ...
        }
        /// <summary>
        /// Rotates a point around the origin (0,0)
        /// </summary>
        private static PointF Rotate(PointF p, float angle)
        {
            // convert from angle to radians
            var theta = Math.PI*angle/180;
            return new PointF(
                (float) (Math.Cos(theta)*(p.X) - Math.Sin(theta)*(p.Y)),
                (float) (Math.Sin(theta)*(p.X) + Math.Cos(theta)*(p.Y)));
        }
