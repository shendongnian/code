    public class ConvexHull6
    {
        public class PointDistance
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double distance { get; set; }
            public int index { get; set; }
        }
        public class StormPointsDistance
        {
            public StormPoints stormPoints { get; set; }
            public Double distance { get; set; }
        }
        public static List<PointD> ReOrderPointsByClosestPointFirst(List<PointD> points, bool islower = false)
        {
            var minX = points.Min(p => p.X);
            var maxX = points.Max(p => p.X);
            var minP = points.First(p => p.X == minX);
            var maxP = points.First(p => p.X == maxX);
            minP = points.First(p => p.X == minX);
            maxP = points.First(p => p.X == maxX);
            var pB = points.ToList();
            var len = pB.Count();
            //Temporary lists to hold data structures and points when performing the points sorting..
            var pDist = new List<PointDistance>();
            var distances = new List<Double>();
            int index = 0;
            //Sorted list to hold final points...
            var sorted = new List<PointD>();
            for (int i = 0; i < len; i++)
            {
                if (i > 0)
                {
                    //Minimum point or "Point of Reference for comparison" is now the last point in the sorted list.
                    minP = sorted[sorted.Count() - 1];
                    //Clear the temporary lists used...
                    pDist.Clear(); distances.Clear();
                }
                for (int j = 0; j < len - i; j++)
                {
                    var distance = Math.Sqrt(Math.Pow(pB[j].X - minP.X, 2) + Math.Pow(pB[j].Y - minP.Y, 2));
                    pDist.Add(new PointDistance() { X = pB[j].X, Y = pB[j].Y, distance = distance, index = index });
                    distances.Add(distance);
                }
                //Order the data structure
                pDist = pDist.OrderBy(m => m.distance).ToList();
                //Convert to points list for use
                pB = pDist.Select(m => new PointD(m.X, m.Y)).ToList();
                //Get the first point and put it in the sorted list
                sorted.Add(pB[0]);
                //Remove the point from the pb list so that it is not considered again
                pB.RemoveAt(0);
                index++;
            }
            pDist = pDist.OrderBy(m => m.distance).ToList();
            distances = pDist.Select(m => m.distance).ToList();
            //The new code...
            points = sorted.ToList();
            //Get the minimum Point again as minP has been overwritten during the loop
            minX = points.Min(p => p.X);
            maxX = points.Max(p => p.X);
            minP = points.First(p => p.X == minX);
            maxP = points.First(p => p.X == maxX);
            //Check if minp does nott match the first point
            if ((minP != points[0] && maxP == points[0]) || (maxP != points[len - 1] && minP == points[len - 1]))
            {
                //Reverse only if the first point of array is not the minimum point
                points.Reverse();
            }
            return points;
        }
       
    }
