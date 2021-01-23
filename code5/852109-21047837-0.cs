    private void randomPaint(int numberOfTimes)
    {
        Random r = new Random();
        Color rC;
        SolidBrush b1;
        Panel p = new Panel();
        p.Height = 250;
        p.Width = 250;
        p.Location = new Point(0, 0);
        this.Controls.Add(p);
        p.BringToFront();
        Graphics g = p.CreateGraphics();
        for (int i = 0; i < numberOfTimes; i++)
        {
            rC = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            b1 = new SolidBrush(rC);
            g.FillEllipse(b1, r.Next(p.Size.Width), r.Next(p.Size.Height), 30, 30);
        }
    }
