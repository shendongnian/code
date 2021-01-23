    Point downPoint;
    private void button1_MouseDown(object sender, MouseEventArgs e)
    {
        downPoint = e.Location;
    }
    private void button1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left) {
            button1.Left += e.X - downPoint.X;
            button1.Top += e.Y - downPoint.Y;
        }
    }
