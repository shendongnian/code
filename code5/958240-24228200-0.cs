    GraphicsPath GP = new GraphicsPath();
    List<Point> PL = new List<Point>();    //**
    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        int diameter = 22;  // put in the size of your circle
        Size s = new Size(diameter, diameter);
        if (!GP.IsVisible(e.Location))
        {
            Point middle = new Point(e.X - diameter / 2, e.Y - diameter / 2);
            GP.AddEllipse(new Rectangle(middle, s));
            PL.Add(middle);    //**
        }
        this.Invalidate();
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        // e.Graphics.DrawPath(Pens.Firebrick, GP);
        Image img = new Bitmap("D:\\circle22.png");  //**
        foreach(Point pt in PL) e.Graphics.DrawImage(img, pt);  //**
        img.Dispose();   //**
    }
