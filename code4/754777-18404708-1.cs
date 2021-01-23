    using System.Collections.Generic;
    using System.Linq;
    using System;
    namespace ConsoleApplication1
    {
        public class Waypoint
        {
            public Point P;
            public bool Visited;
        }
        public class Point : IEquatable<Point>
        {
            public double X;
            public double Y;
     
            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }
     
            public bool Equals(Point other)
            {
                if (Object.ReferenceEquals(other, null)) return false;
                if (Object.ReferenceEquals(this, other)) return true;
     
                return X.Equals(other.X) && Y.Equals(other.Y);
            }
     
            public override int GetHashCode()
            {
                int hashX = X.GetHashCode();
     
                int hashY = Y.GetHashCode();
     
                return hashX ^ hashY;
            }
        }
     
        class Program
        {
            static List<Point> AllPoints = new List<Point>();
            static Point startPoint = new Point(0, 0);
            static Point endPoint = new Point(4, 3);
            static List<List<Waypoint>> weightedList = new List<List<Waypoint>>();
     
            static void Main(string[] args)
            {
                AllPoints.Add(new Point(0, 0));
                AllPoints.Add(new Point(1, 1));
                AllPoints.Add(new Point(1, 2));
                AllPoints.Add(new Point(1, 3));
                AllPoints.Add(new Point(2, 2));
                AllPoints.Add(new Point(2, 3));
                AllPoints.Add(new Point(3, 2));
                AllPoints.Add(new Point(3, 3));
                AllPoints.Add(new Point(4, 3));
     
                // select all points within reach, its a 1x1 square between points so the max distance is 1.42
                var filteredList = from p in AllPoints
                         where DistanceBetweenTwoPoints(p, startPoint) < 1.42 && p.X != startPoint.X && p.Y != startPoint.Y
                         select p;
     
                List<Waypoint> currList = new List<Waypoint>();
                currList.Add(new Waypoint() { P = new Point(startPoint.X, startPoint.Y), Visited = true });
     
                foreach (var p in filteredList)
                {
                    currList.Add(new Waypoint() { P = new Point(p.X, p.Y), Visited = true });
 
                    RecusivlyVisitPoint(currList.Last(), currList);
                }
                var min = weightedList.OrderBy(w => w.Count).Take(1).ToList();
            }
     
            static void RecusivlyVisitPoint(Waypoint wp, List<Waypoint> list)
            {
                // we have reached the end
                if (wp.P.Equals(endPoint))
                {
                    weightedList.Add(list);
     
                    return;
                }
     
                // select all points within reach, its a 1x1 square between points so the max distance is 1.42
                var allPointsWithInReach = AllPoints.FindAll(p => DistanceBetweenTwoPoints(p, wp.P) < 1.42);
     
                // filter with already visited
                allPointsWithInReach = allPointsWithInReach.Except(list.Select(w => w.P)).ToList();
     
                // there are no other points to go thru
                if (allPointsWithInReach.Count == 0)
                {
                    //weightedList.Add(list);
                    // but you didn't get trough the end so it's not a possibility
                    return;
                }
     
                // recursivly go thru the list
                foreach (var p in allPointsWithInReach)
                {
                    List<Waypoint> newList = new List<Waypoint>();
                    foreach (var e in list)
                        newList.Add(e);
     
                    newList.Add(new Waypoint() { P = new Point(p.X, p.Y), Visited = true });
     
                    RecusivlyVisitPoint(newList.Last(), newList);
                }
            }
     
            static double DistanceBetweenTwoPoints(Point p1, Point p2)
            {
                return Math.Sqrt(Math.Pow(Math.Abs(p1.X - p2.X), 2) + Math.Pow(Math.Abs(p1.Y - p2.Y), 2));
            }
        }
    }
