    private Stack<Line> lines = new Stack<Line>();
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        lines.Push(new Line { Start = e.Location });
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (lines.Count > 0 && e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            lines.Peek().End = e.Location;
            pictureBox1.Invalidate();
        }
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        foreach (var line in lines)
        {
            e.Graphics.DrawLine(Pens.Black, line.Start, line.End);
        }
    }
    class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }
    }
