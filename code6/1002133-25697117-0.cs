        public static PathGeometry ClipGeometry(PathGeometry geom, Rect clipRect)
        {
            PathGeometry clipped = new PathGeometry();
            foreach (var fig in geom.Figures)
            {
                PathSegmentCollection segments = new PathSegmentCollection();
                Point lastPoint = fig.StartPoint;
                foreach (LineSegment seg in fig.Segments)
                {
                    List<Point> points;
                    if (LineIntersectsRect(lastPoint, seg.Point, clipRect, out points))
                    {
                        LineSegment newSeg = new LineSegment(points[1], true);
                        PathFigure newFig = new PathFigure(points[0], new[] { newSeg }, false);
                        clipped.Figures.Add(newFig);
                    }
                    lastPoint = seg.Point;
                }
            }
            return clipped;
        }
        static bool LineIntersectsRect(Point lineStart, Point lineEnd, Rect rect, out List<Point> points)
        {
            points = new List<Point>();
            if (rect.Contains(lineStart) && rect.Contains(lineEnd))
            {
                points.Add(lineStart);
                points.Add(lineEnd);
                return true;
            }
            Point outPoint;
            if (Intersects(lineStart, lineEnd, rect.TopLeft, rect.TopRight, out outPoint))
            {
                points.Add(outPoint);
            }
            if (Intersects(lineStart, lineEnd, rect.BottomLeft, rect.BottomRight, out outPoint))
            {
                points.Add(outPoint);
            }
            if (Intersects(lineStart, lineEnd, rect.TopLeft, rect.BottomLeft, out outPoint))
            {
                points.Add(outPoint);
            }
            if (Intersects(lineStart, lineEnd, rect.TopRight, rect.BottomRight, out outPoint))
            {
                points.Add(outPoint);
            }
            if (points.Count == 1)
            {
                if (rect.Contains(lineStart))
                    points.Add(lineStart);
                else
                    points.Add(lineEnd);
            }
            return points.Count > 0;
        }
        static bool Intersects(Point a1, Point a2, Point b1, Point b2, out Point intersection)
        {
            intersection = new Point(0, 0);
            Vector b = a2 - a1;
            Vector d = b2 - b1;
            double bDotDPerp = b.X * d.Y - b.Y * d.X;
            if (bDotDPerp == 0)
                return false;
            Vector c = b1 - a1;
            double t = (c.X * d.Y - c.Y * d.X) / bDotDPerp;
            if (t < 0 || t > 1)
                return false;
            double u = (c.X * b.Y - c.Y * b.X) / bDotDPerp;
            if (u < 0 || u > 1)
                return false;
            intersection = a1 + t * b;
            return true;
        }
