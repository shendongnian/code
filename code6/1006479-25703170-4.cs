    public Form1()
    {
        InitializeComponent();
        // most real states don't look like rectangles
        Region r = new Region(new Rectangle(0, 0, 99, 99));
        regions.Add(r);
        r = new Region(new Rectangle(166,166,99,991));
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
