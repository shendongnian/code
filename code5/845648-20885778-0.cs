    private void randomPaint(int numberOfTimes)
    {
        Random r = new Random();
        Graphics g = this.CreateGraphics();
        Color rC;
        SolidBrush b1;
   
        for (int i = 0; i < numberOfTimes; i++)
        {    
            // Randomize a color
            rC = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            b1 = new SolidBrush(rC);
            // Paint with random position
            g.FillEllipse(b1, r.Next(this.Size.Width), r.Next(this.Size.Height), 30, 30);
        }
    }
