    bool isMouseDown = false;
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        isMouseDown = true;
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        isMouseDown = false;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (isMouseDown)
        {
            g.FillEllipse(brush, ((MouseEventArgs)e.UserState).X - (int)dimensions / 2, ((MouseEventArgs)e.UserState).Y - (int)dimensions / 2, (int)dimensions, (int)dimensions);
            dimensions += 0.2;
            Thread.Sleep(10);
        }
    }
