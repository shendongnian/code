     private void button1_Click(object sender, EventArgs e)
                {
                    int radius = 100;
                    var p = new Pen(Color.Black);
                    var g = this.CreateGraphics();
                    g.DrawEllipse(p, 0,0,radius*2, radius*2);
                    var pointGen = new RandomPointGenerator();
                    var randomPoints = pointGen.GetPointsInACircle(radius, 20);
                    p.Color = Color.Red;
                    foreach (var point in randomPoints)
                    {
        
                        g.DrawEllipse(p, point.X + radius, point.Y+radius, 2, 2);
                    }
                }
 
    public class RandomPointGenerator
        {
            private Random _randy = new Random();
            public List<Point> GetPointsInACircle(int radius, int numberOfPoints)
            {
                List<Point> points = new List<Point>();
                for (int pointIndex = 0; pointIndex < numberOfPoints; pointIndex++)
                {
                    int distance = _randy.Next(radius);
                    double angleInRadians = _randy.Next(360)/(2 * Math.PI) ;
    
                    int x = (int)(distance * Math.Cos(angleInRadians));
                    int y = (int)(distance * Math.Sin(angleInRadians));
                    Point randomPoint = new Point(x, y);
                    points.Add(randomPoint);
                }
                return points;
            }
        }
