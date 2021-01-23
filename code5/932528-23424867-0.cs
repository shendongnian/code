    private Stack<Point> points = new Stack<Point>();
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        points.Clear();
        points.Push(e.Location);
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (points.Count > 1)
        {
            points.Pop();
        }
        if (points.Count > 0 && e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            points.Push(e.Location);
            pictureBox1.Invalidate();
        }
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (points.Count > 1)
            e.Graphics.DrawLines(Pens.Black, points.ToArray());
    }
