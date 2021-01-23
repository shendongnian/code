    //..
    using System.Drawing.Drawing2D;
    //..
    public Form1()
    {
        InitializeComponent();
        // most real states don't look like rectangles
        Region r = new Region(new Rectangle(0, 0, 99, 99));
        regions.Add(r);
        List<int> coords = new List<int>() {23,137, 76,151, 61,203, 
                           117,283, 115,289, 124,303, 112,329, 76,325, 34,279, 11,162};
        List<Point> points = new List<Point>();
        for (int i = 0; i < coords.Count ; i += 2) 
                            points.Add(new Point(coords[i], coords[i+1]));
        byte[] fillmodes = new byte[points.Count];
        for (int i = 0 ; i < fillmodes.Length; i++) fillmodes[i] = 1;
        GraphicsPath GP = new GraphicsPath(points.ToArray(), fillmodes);
        regions.Add(r);
    }
    List<Region> regions = new List<Region>();
    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        using (Graphics G = pictureBox1.CreateGraphics() )
        foreach(Region r in regions)
        {
            Region ri = r.Clone();
            ri.Intersect(new Rectangle(e.X, e.Y, 1, 1));
            if (!ri.IsEmpty(G))  // hurray, we got a hit
                { this.Text = r.GetBounds(G).ToString(); break; }
        }
                
    }
