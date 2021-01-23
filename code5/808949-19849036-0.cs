    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            picCanvas.Paint += new PaintEventHandler(picCanvas_Paint);
            picCanvas.MouseDown += new MouseEventHandler(picCanvas_MouseDown);
        }
        private int circleSize = 30;
        private Random R = new Random();
        private List<Color> NamedColors = new List<Color>();
        private List<Tuple<Point, Color>> Circles = new List<Tuple<Point, Color>>();
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Color C in System.ComponentModel.TypeDescriptor.GetConverter(typeof(Color)).GetStandardValues())
            {
                if (C.IsNamedColor)
                {
                    NamedColors.Add(C);
                }
            }
        }
        void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            Tuple<Point, Color> circle = new Tuple<Point, Color>(
                new Point(e.X, e.Y), 
                NamedColors[R.Next(NamedColors.Count)]);
            Circles.Add(circle);
            picCanvas.Invalidate();
        }
        void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (Tuple<Point, Color> circle in Circles)
            {
                Rectangle rc = new Rectangle(circle.Item1, new Size(1, 1));
                rc.Inflate(circleSize / 2, circleSize / 2);
                using (Pen pen = new Pen(circle.Item2, 3))
                {
                    e.Graphics.DrawEllipse(pen, rc);
                }
            }
        }
    }
