    public static PointCollection getPointsFromPath(Path path)
        {
            PointCollection pathPointsCollection = new PointCollection();
            PathFigure pathFigure = null;
            PolyBezierSegment polyBezierSegment = null;
            PathGeometry pathGeometry = (PathGeometry)path.Data;
            PathFigureCollection pathFigureCollection = pathGeometry.Figures;
            if (pathFigureCollection.Count > 0)
            {
                try
                {
                    pathFigure = pathFigureCollection.ElementAt(0);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception found at getting path figure=" + e);
                }
                if (pathFigure != null)
                {
                    PathSegmentCollection pathSegmentCollection = pathFigure.Segments;
                    try
                    {
                        polyBezierSegment = (PolyBezierSegment)pathSegmentCollection[0];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception found at getting polyBezierSegment =" + e);
                    }
                    if (polyBezierSegment != null)
                    {
                        pathPointsCollection = polyBezierSegment.Points;
                    }
                }
            }
            //Console.WriteLine("pathPointsCollection.Count=" + pathPointsCollection.Count + " values=" + pathPointsCollection.ToString());
            return pathPointsCollection;
        }
