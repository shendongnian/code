    bool paint = false;
    protected override void OnPaint(object sender, PaintEventArgs e)
    {
        if (paint) 
        {
              Pen pen = new Pen(Color.Black, 3); Graphics gr = this.CreateGraphics(); gr.DrawEllipse(pen, 40, 45, 20, 20);
              Pen pen2 = new Pen(Color.Black, 3); Graphics gr1 = this.CreateGraphics(); gr.DrawEllipse(pen2, 30, 25, 38, 20);
              Pen pen3 = new Pen(Color.Black, 3); Graphics gr2 = this.CreateGraphics(); gr.DrawEllipse(pen3, 35, 36, 68, 15);
              Pen pen4 = new Pen(Color.Black, 3); Graphics gr3 = this.CreateGraphics(); gr.DrawEllipse(pen4, 50, 60, 67, 35);
        }
    }
