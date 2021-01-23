    private void Form1_Load(object sender, EventArgs e)
    {
        System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
        myPath.AddLines(new Point[]
            {
                new Point(0, Height / 2),
                new Point(Width / 2, 0),
                new Point(Width, Height / 2),
                new Point(Width / 2, Height)
            });
        Region myRegion = new Region(myPath); 
        this.Region = myRegion;
    }
