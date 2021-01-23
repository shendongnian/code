    List<DrawAction> actions = new List<DrawAction>();
    public class DrawAction
    {
        public char type { get; set; }             // this should be an Enum!
        public Color color { get; set; }     
        public float penWidth { get; set; }        // only one of many Pen properties!
        public List<Point> points { get; set; }    // use PointF for more precision
        public DrawAction(char type_, Color color_, float penwidth_)
        {
            type = type_; color = color_; penWidth = penwidth_;
            points = new List<Point>();
        }
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        Draw(e.Graphics, actions);
    }
    public void Draw(Graphics G, List<DrawAction> actions)
    {
        foreach (DrawAction da in actions)
            if (da.type == 'L' && da.points.Count > 1)
                using (Pen pen = new Pen(da.color, da.penWidth))
                    G.DrawLine(pen, da.points[0], da.points[1]);
            else if (da.type == 'P' && da.points.Count > 1)
                using (Pen pen = new Pen(da.color, da.penWidth))
                    G.DrawLines(pen, da.points.ToArray());
        // else..
    }
    private void button1_Click(object sender, EventArgs e)
    {
        AddTextActions();
        pictureBox1.Invalidate();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        AddTextActions();
        Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width, 
                                pictureBox1.ClientSize.Height);
        using (Graphics G = Graphics.FromImage(bmp))  Draw(G, actions);
        pictureBox1.Image = bmp;
    }
    void AddTextActions()
    {
        actions.Add(new DrawAction('L', Color.Blue, 3.3f));
        actions[0].points.Add(new Point(23, 34));
        actions[0].points.Add(new Point(23, 134));
        actions.Add(new DrawAction('P', Color.Red, 1.3f));
        actions[1].points.Add(new Point(11, 11));
        actions[1].points.Add(new Point(55, 11));
        actions[1].points.Add(new Point(55, 77));
        actions[1].points.Add(new Point(11, 77));
    }
