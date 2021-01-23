    public static class PictureBoxExtensions
    {
       public static Point ToCartesian(this PictureBox box, Point p)
       {
          return new Point(p.X, p.Y - box.Height);
       }
       public static Point FromCartesian(this PictureBox box, Point p)
       {
          return new Point(p.X, box.Height - p.Y);
       }
    }
