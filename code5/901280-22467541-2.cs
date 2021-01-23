    private void Form1_Load(object sender, EventArgs e)
    {
        using (GraphicsPath myPath = new GraphicsPath())
        {
            myPath.AddLines(new[]
                {
                    new Point(0, Height / 2),
                    new Point(Width / 2, 0),
                    new Point(Width, Height / 2),
                    new Point(Width / 2, Height)
                });
            Region = new Region(myPath);
        }
    }
