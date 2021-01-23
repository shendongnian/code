    public partial class Form1 : Form
    {
        private Matrix MyMatrix = new Matrix();
        private List<Point> Points = new List<Point>();
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Shown += new EventHandler(Form1_Shown);
        }
        void Form1_Shown(object sender, EventArgs e)
        {
            Point Center = new Point(this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2);
            MyMatrix.Translate(Center.X, Center.Y);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.Paint += new PaintEventHandler(Form1_Paint);
        }
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Transform = MyMatrix;
            // draw the origin in the center of the form:
            e.Graphics.DrawLine(Pens.Red, new Point(-10, 0), new Point(10, 0));
            e.Graphics.DrawLine(Pens.Red, new Point(0, -10), new Point(0, 10));
            // draw our stored points (that have already been converted to world coords)
            foreach (Point pt in Points)
            {
                Rectangle rc = new Rectangle(pt, new Size(1, 1));
                rc.Inflate(10, 10);
                e.Graphics.DrawRectangle(Pens.Black, rc);
            }
        }
        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Matrix m = MyMatrix.Clone();
            m.Invert();
            Point[] pts = new Point[] {new Point(e.X, e.Y)};
            m.TransformPoints(pts);
            Points.Add(pts[0]);
            this.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MyMatrix.Rotate(10);
            this.Refresh();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MyMatrix.Scale(1.1f, 1.1f);
            this.Refresh();
        }
    }
