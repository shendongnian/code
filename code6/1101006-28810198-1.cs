        /// <summary>
        /// Make sure it is structure.
        /// </summary>
        public struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int DistanceSqrt()
            {
                return X * X + Y * Y;
            }
        }
        /// <summary>
        /// Points ordered by distance from center that are on "border" of the circle.
        /// </summary>
        public static PriorityQueue<Point> _pointsToAdd = new PriorityQueue<Point>();
        /// <summary>
        /// Set of pixels that were already added, so we don't visit single pixel twice. Could be replaced with 2D array of bools.
        /// </summary>
        public static HashSet<Point> _addedPoints = new HashSet<Point>();
        public static List<Point> FillCircle(int radius)
        {
            List<Point> points = new List<Point>();
            _pointsToAdd.Enqueue(new Point { X = 1, Y = 0 }, 1);
            _pointsToAdd.Enqueue(new Point { X = 1, Y = 1 }, 2);
            points.Add(new Point {X = 0, Y = 0});
            while(true)
            {
                var point = _pointsToAdd.Dequeue();
                _addedPoints.Remove(point);
                if (point.X >= radius)
                    break;
                points.Add(new Point() { X = -point.X, Y = point.Y });
                points.Add(new Point() { X = point.Y, Y = point.X });
                points.Add(new Point() { X = -point.Y, Y = -point.X });
                points.Add(new Point() { X = point.X, Y = -point.Y });
                // if the pixel is on border of octant, then add it only to even half of octants
                bool isBorder = point.Y == 0 || point.X == point.Y;
                if(!isBorder)
                {
                    points.Add(new Point() {X = point.X, Y = point.Y});
                    points.Add(new Point() {X = -point.X, Y = -point.Y});
                    points.Add(new Point() {X = -point.Y, Y = point.X});
                    points.Add(new Point() {X = point.Y, Y = -point.X});
                }
                Point pointToLeft = new Point() {X = point.X + 1, Y = point.Y};
                Point pointToLeftTop = new Point() {X = point.X + 1, Y = point.Y + 1};
                if(_addedPoints.Add(pointToLeft))
                {
                    // if it is first time adding this point
                    _pointsToAdd.Enqueue(pointToLeft, pointToLeft.DistanceSqrt());
                }
                if(_addedPoints.Add(pointToLeftTop))
                {
                    // if it is first time adding this point
                    _pointsToAdd.Enqueue(pointToLeftTop, pointToLeftTop.DistanceSqrt());
                }
            }
            return points;
        }
