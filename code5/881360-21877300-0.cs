        private readonly Stack<Point> _points = new Stack<Point>();
        private readonly Pen _blackPen = new Pen(Color.Black);
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var points = _points.ToArray();
            for (int i = 1; i < points.Length; i++)
            {
                e.Graphics.DrawLine(_blackPen, points[i - 1], points[i]);
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _points.Push(e.Location);
            Invalidate();
        }
