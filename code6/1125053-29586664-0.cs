    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            pairs.Add(new Tuple<Control, Control>(textBox1, textBox2));
        }
        List<Tuple<Control, Control>> pairs = new List<Tuple<Control, Control>>();
        Point mDown = Point.Empty;
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            foreach (Tuple<Control, Control> cc in pairs)
                drawConnection(e.Graphics, cc.Item1, cc.Item2);
        }
        void drawConnection(Graphics G, Control c1, Control c2)
        {
            using (Pen pen = new Pen(Color.DeepSkyBlue, 3f) )
            {
                Point p1 = new Point(c1.Left + c1.Width / 2, c1.Top + c1.Height / 4);
                Point p2 = new Point(c2.Left + c2.Width / 2, c2.Top + c2.Height / 4);
                G.DrawLine(pen, p1, p2);
            }
        }
        void DragBox_MouseDown(object sender, MouseEventArgs e)
        {
            mDown = e.Location;
        }
        void DragBox_MouseMove(object sender, MouseEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.Button == MouseButtons.Left)
            {
                tb.Location = new Point(e.X + tb.Left - mDown.X, e.Y + tb.Top - mDown.Y);
            }
        }
        void DragBox_MouseUp(object sender, MouseEventArgs e)
        {
            mDown = Point.Empty;
        }
        private void DragBox_Move(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
