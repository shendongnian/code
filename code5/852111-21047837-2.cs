    private void randomPaint(int numberOfTimes)
    {
        Random r = new Random();
        Color rC;
        SolidBrush b1;
        Graphics g = pnlDraw.CreateGraphics();
        for (int i = 0; i < numberOfTimes; i++)
        {
            rC = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            b1 = new SolidBrush(rC);
            g.FillEllipse(b1, r.Next(pnlDraw.Size.Width), r.Next(pnlDraw.Size.Height), 30, 30);
        }
    }
