        #region FnLineMerginRectandLines
        public static bool LineIntersectsRect(Point p1, Point p2, Rectangle r)
        {
            return LineIntersectsLine(p1, p2, new Point(r.X, r.Y), new Point(r.X + r.Width, r.Y)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y), new Point(r.X + r.Width, r.Y + r.Height)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y + r.Height), new Point(r.X, r.Y + r.Height)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X, r.Y + r.Height), new Point(r.X, r.Y)) ||
                   (r.Contains(p1) && r.Contains(p2));
        }
        private static bool LineIntersectsLine(Point l1p1, Point l1p2, Point l2p1, Point l2p2)
        {
            float q = (l1p1.Y - l2p1.Y) * (l2p2.X - l2p1.X) - (l1p1.X - l2p1.X) * (l2p2.Y - l2p1.Y);
            float d = (l1p2.X - l1p1.X) * (l2p2.Y - l2p1.Y) - (l1p2.Y - l1p1.Y) * (l2p2.X - l2p1.X);
            if (d == 0)
            {
                return false;
            }
            float r = q / d;
            q = (l1p1.Y - l2p1.Y) * (l1p2.X - l1p1.X) - (l1p1.X - l2p1.X) * (l1p2.Y - l1p1.Y);
            float s = q / d;
            if (r < 0 || r > 1 || s < 0 || s > 1)
            {
                return false;
            }
            return true;
        }
        #endregion
    public class Line
    {
        private int Point1X;
        private int Point1Y;
        private int Point2X;
        private int Point2Y;
        public Point P1;
        public Point P2;
        
        public Line()
        {
    
        }
        public Line(int left, int top, int width, int height)
        {
            this.Point1X = Convert.ToInt32(left);
            this.Point1Y = Convert.ToInt32(top);
            this.Point2X = Convert.ToInt32(width);
            this.Point2Y = Convert.ToInt32(height);
            P1 = new Point(Point1X, Point1Y);
            P2 = new Point(Point2X, Point2Y);
        }
        public Line(string left, string top, string width, string height)
        {
            this.Point1X = Convert.ToInt32(left);
            this.Point1Y = Convert.ToInt32(top);
            this.Point2X = Convert.ToInt32(width);
            this.Point2Y = Convert.ToInt32(height);
            P1 = new Point(Point1X, Point1Y);
            P2 = new Point(Point2X, Point2Y);
        }   
        public Line(Point p1, Point P2)
        {
            this.P1 = p1;
            this.P2 = P2;
        }
    }
   
    public static List<Line>getfourborders(Rectangle RT)
        {
            Line topline = new Line(new Point(RT.Left,RT.Top),new Point(RT.Width+RT.Left,RT.Top));// Top Line
            Line leftline = new Line((new Point(RT.Left,RT.Top)),new Point(RT.Left,RT.Top+RT.Height));// left Line
            Line  rightline = new Line((new Point(RT.Left+RT.Width,RT.Top)),new Point(RT.Left + RT.Width,RT.Top+RT.Height));// Right Line
            Line bottomline = new Line((new Point(RT.Left,RT.Top+RT.Height)),new Point(RT.Left+RT.Width,RT.Top+RT.Height));//bottom line
            List<Line> borderlines = new List<Line>();
            borderlines.Add(leftline);
            borderlines.Add(topline);
            borderlines.Add(rightline);
            borderlines.Add(bottomline);
            return borderlines;
        }
     //YourObjectList() contains a rectangle type
            public class myobject
            {
                public myobject(object S, Rectangle RT)
                {
                this.Rt = RT;
                this.anyobjecttype= S;
                }
                public Rectangle Rt;
                public  object anyobjecttype ;
            }
    
            public List<myobject> CompareRectangles(List<myobject> Rect ,Rectangle GivenRectangle)
            {
                List<myobject> intersectingobjects = new List<myobject>();
                Rectangle CompareWith = new Rectangle();//"_objects.Where(_ => rc.IntersectsWith(_.InscribeRect));"
                
                foreach(myobject iterate in Rect)
                {
                    List<Line> BorderLines = new List<Line>();
                    BorderLines.AddRange(getfourborders(iterate.Rt));
                    bool Intersects = BorderLines.Any(x=>LineIntersectsRect(x.P1,x.P2,CompareWith));
                    if (Intersects)
                        intersectingobjects.Add(iterate);
                }
                return intersectingobjects;
            }
