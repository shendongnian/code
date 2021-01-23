        public class StrokeCollection : List<Stroke>
        {
        }
    
        public class Stroke : List<Point>
        {
            public Point[][] Points { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                StrokeCollection lst = new StrokeCollection();
    
    
                Random rnd1 = new Random(3);
                Random rnd2 = new Random(13);
    
    
                for (int i = 0; i < 10; i++)
                {
                    int x = rnd1.Next(1, 5);
                    var s = new Stroke { Points = new Point[x][] };
                    foreach (var r in Enumerable.Range(0, x))
                    {
                        int y = rnd1.Next(1, 5);
                        s.Points[r] = new Point[y];
    
                        for (int j = 0; j < y; j++)
                            s.Points[r][j] = new Point(rnd2.Next(-50, 80), rnd2.Next(-20, 20));
                    }
                    lst.Add(s);
                }
    
                Point leftMostPoint = Point.Empty;
                Point rightMostPoint = Point.Empty;
    
                lst.ForEach(p1 =>
                {
                    foreach (Point[] p2 in p1.Points)
                    {
                        foreach (var p3 in p2)
                        {
                            if (leftMostPoint == Point.Empty)
                                leftMostPoint = p3;
    
                            if (rightMostPoint == Point.Empty)
                                rightMostPoint = p3;
    
                            if (p3.X < leftMostPoint.X)
                                leftMostPoint = p3;
    
                            if (p3.X > rightMostPoint.X)
                                rightMostPoint = p3;
                        }
                    }
                });
    
                Console.WriteLine("Leftmost point " + leftMostPoint.ToString());
                Console.WriteLine("Rightmost point " + rightMostPoint.ToString());
           }
       }
