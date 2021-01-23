        /// <summary>
        /// Find discreet coordinates where the line y=mx+b intersects the edges of a w-by-h image.
        /// </summary>
        /// <param name="m">slope of the line</param>
        /// <param name="b">y-intercept of the line</param>
        /// <param name="w">width of the image</param>
        /// <param name="h">height of the image</param>
        /// <returns>the points of intersection</returns>
        List<Point> GetIntersectionsForImage(double m, double b, double w, double h)
        {
            var intersections = new List<Point>();
            // Check for intersection with left side (y-axis).
            if (b >= 0 && b <= h)
            {
                intersections.Add(new Point(0.0, b));
            }
            // Check for intersection with right side (x=w).
            var yValRightSide = m * w + b;
            if (yValRightSide >= 0 && yValRightSide <= h)
            {
                intersections.Add(new Point(w, yValRightSide));
            }
            // If the slope is zero, intersections with top or bottom will be taken care of above.
            if (m != 0.0)
            {
                // Check for intersection with top (y=h).
                var xValTop = (h - b) / m;
                if (xValTop >= 0 && xValTop <= w)
                {
                    intersections.Add(new Point(xValTop, h));
                }
                // Check for intersection with bottom (y=0).
                var xValBottom = (0.0 - b) / m;
                if (xValBottom >= 0 && xValBottom <= w)
                {
                    intersections.Add(new Point(xValBottom, 0));
                }
            }
            return intersections;
        }
