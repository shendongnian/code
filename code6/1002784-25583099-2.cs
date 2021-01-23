    public class Paintballs
    {
        private List<Point> myClick;
        public Paintballs()
        {
            myClick = new List<Point>();
        }
        public void Add(Point location)
        {
            myClick.Add(location);
        }
        public void Paint(Graphics g)
        {
            foreach (Point p in myClick)
            {
                g.FillEllipse(Brushes.Blue, p.X, p.Y, 20, 20);
            }
        }
    }
