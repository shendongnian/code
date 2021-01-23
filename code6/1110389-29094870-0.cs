    using System;
    using System.Collections.Generic;
    using System.Drawing;
    namespace ConsoleApplication2
    {
        class Program
        {
            private static void Main()
            {
                var points = new List<Point>();
                int screenWidth     = 1920;
                int screenHeight    = 1280;
                int numPointsWanted =  100;
                long nearestAllowedSquared = 200*200;
                Random rng = new Random(12345);
                while (points.Count < numPointsWanted)
                {
                    int randXpixels = rng.Next(24, screenWidth - 16);
                    int randYpixels = rng.Next(27, screenHeight - 27);
                    var point = new Point(randXpixels, randYpixels);
                    if (distanceToNearestPointSquared(point, points) >= nearestAllowedSquared)
                    {
                        points.Add(point);
                        Console.WriteLine(points.Count);
                    }
                }
            }
            private static long distanceToNearestPointSquared(Point point, IEnumerable<Point> points)
            {
                long nearestDistanceSquared = long.MaxValue;
                foreach (var p in points)
                {
                    int dx = p.X - point.X;
                    int dy = p.Y - point.Y;
                    long distanceSquared = dx*dx + dy*dy;
                    nearestDistanceSquared = Math.Min(nearestDistanceSquared, distanceSquared);
                }
                return nearestDistanceSquared;
            }
        }
    }
