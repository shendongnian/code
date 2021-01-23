    public partial class SomeForm : Form
    {
      protected override void OnPaint(PaintEventArgs e)
      {
        Graphics g = e.Graphics;
        // some code to define x1, y1, colors, etc
        gpset(g, x1, y1, color1);
        gline(g, x1, y1, x2, y2, color1);
        gbox(g, x1, y1, x2, y2, color1);
      }
      public void gpset(Graphics g, int x1, int y1, string colour1)
      {
        Pen myPen = new Pen(Color.FromName(colour1));
        g.DrawLine(myPen, x1, y1, x1 + 1, y1 + 1);
        myPen = new Pen(Color.White);
        g.DrawLine(myPen, x1 + 1, y1, x1 + 1, y1 + 1);
        myPen.Dispose();
        g.Dispose();
      }
    
      public void gline(Graphics g, int x1, int y1, int x2, int y2, string colour1)
      {
        Pen myPen = new Pen(Color.FromName(colour1));
        g.DrawLine(myPen, x1, y1, x2, y2);
        myPen.Dispose();
        g.Dispose();
      }
    
      public void gbox(Graphics g, int x1, int y1, int x2, int y2, string colour1)
      {
        Pen myPen = new Pen(Color.FromName(colour1));
        g.DrawRectangle(myPen, x1, y1, x2, y2);
        myPen.Dispose();
        g.Dispose();
      }
    }
