    public class Delta
    {
        public Point P1 { get;set; }
        public Point P2 { get;set; }
        
        public static Delta Create(Point P1, Point P2)
        {
            return new Delta {
                P1 = P1,
                P2 = P2
            };
        }
        
        public override string ToString()
        {
            return string.Format("Delta is (" + (P2.X - P1.X)
                + "," + (P2.Y - P1.Y) + ")");
        }
    }
