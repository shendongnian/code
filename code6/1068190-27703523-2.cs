    protected override void OnResize(EventArgs e)
    {
        button1.Location = new Point()
        {
            X = panel1.Width / 2 - button1.Width / 2,
            Y = panel1.Height / 2 - button1.Height / 2
        };
        base.OnResize(e);
    }
