     //..
     // draw all my lines
       foreach(myLine aLine in myLines)
           using (Pen p = new Pen(aLine.LineColor, aLine.Stroke))
           {
               p.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
               g.DrawLine(p, aLine.X, aLine.Y, aLine.X + aLine.Length, aLine.Y);
           }
    }
    // keeping state of the mouse movement..
    int lastX = 0; int currentX = 0; myLine hitLine = null;
    // a collection of lines
    List<myLine> myLines;
    // a simple horizontal line class
    public class myLine
    {
        private int x;
        public int X
        {
            get { return x; }
            set { x = value; Rect = new Rectangle(x, Y-2, Length, Stroke+4); }
        }
        public int Y { get; set; }
        public int Length { get; set; }
        public int Stroke { get; set; }
        public Color LineColor { get; set; }
        public Rectangle Rect { get; set; }
        public string Name { get; set; }
        public myLine(int x, int y, int length, string name, Color color, int stroke)
        {
            X = x; Y = y; Length = length; Name = name; LineColor = color; Stroke = stroke;
            Rect = new Rectangle(x, Y - 2, Length, Stroke + 4);
        }
    }
    // create a few lines
    private void initLines()
    {
        myLines = new List<myLine>();
        myLines.Add(new myLine(100, 80, 400, "Tom", Color.Red, 6));
        myLines.Add(new myLine(100, 130, 400, "Jerry", Color.Orange, 8));
        myLines.Add(new myLine(100, 180, 400, "Barbera", Color.Blue, 10));
    }
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
       // hittest, show line name in a panel (optional) 
       foreach (myLine aLine in myLines)
           if (aLine.Rect.Contains(e.Location)) { hitLine = aLine; label1.Text = hitLine.Name;  continue; }
       lastX = currentX;
       currentX = e.X;
    }
    private void panel1_MouseUp(object sender, MouseEventArgs e)
    {
       hitLine = null;
    }
    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
       if (e.Button == System.Windows.Forms.MouseButtons.Left)
       {
           lastX = currentX;
           currentX = e.X;
           if (hitLine != null)
           {
               hitLine.X += (currentX - lastX);
               // invalidate a bit more than really needed..
               panel1.Invalidate(new Rectangle(0, hitLine.Y - hitLine.Stroke, panel1.Width, hitLine.Y + hitLine.Stroke));
           }
       }
    }
