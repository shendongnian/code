    public partial class convexHullForm : Form
    {
        private List<Point> Points = new List<Point>();
        public convexHullForm()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(convexHullForm_Paint);
            this.MouseDown += new MouseEventHandler(convexHullForm_MouseDown);
        }
        private void convexHullForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Points.Add(new Point(e.X, e.Y));
                this.Refresh();
            }                                             
        }
        void convexHullForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (Point pt in Points)
            {
                e.Graphics.FillEllipse(Brushes.Blue, pt.X, pt.Y, 20, 20);
            }
        }
    }
