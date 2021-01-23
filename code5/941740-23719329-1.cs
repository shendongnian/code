    // a list of all PacDots:
    public List<PacDot> theDots = new List<PacDot>();
    public class PacDot : System.Windows.Forms.Control
    {
        public PacDot(int x, int y, int w, int h)
        {
            Left = x; Top = y; Width = w; Height = h; 
        }
        public void Draw(Graphics G)
        {
          G.FillEllipse(Brushes.Brown, 
            new System.Drawing.Rectangle(Left, Top, Width,  Height));
        }
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        foreach (PacDot dot in theDots) dot.Draw(e.Graphics);
    }
    // a test button:
    private void button1_Click(object sender, EventArgs e)
    {
        theDots.Add(new PacDot(30, 10, 5, 5));
        theDots.Add(new PacDot(30, 15, 5, 5));
        theDots.Add(new PacDot(15, 10, 5, 5));
        this.Invalidate();
    }
