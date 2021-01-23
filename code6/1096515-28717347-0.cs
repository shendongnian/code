    public partial class Form1 : Form
    {
        private Bitmap bmp; // Place to store our drawings
        private List<Point> points; // Points of currently drawing line
        private Pen pen; // Pen we will use to draw
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true; // To avoid flickering effect
            bmp = new Bitmap(640, 480); // This is our canvas that will store drawn lines
            using (Graphics g = Graphics.FromImage(bmp))
                g.Clear(Color.White); // Let's make it white, like paper
            points = new List<Point>(); // Here we will remember the whole path
            pen = new Pen(Color.Black);
            MouseDown += OnMouseDown; // Start drawing
            MouseMove += OnMouseMove; // Drawing...
            MouseUp += OnMouseUp; // Stop drawing
            Paint += OnPaint; // Show the drawing
        }
        void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0); // Show what is drawn
            if (points.Count > 0)
                e.Graphics.DrawLines(pen, points.ToArray()); // Show what is currently drawing
        }
        void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            points.Clear();
            points.Add(e.Location); // Remember the first point
        }
        void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            points.Add(e.Location); // Add points to path
            Invalidate(); // Force to repaint
        }
        void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            SaveToBitmap(); // Save the drawn line to bitmap
            points.Clear(); // Path is saved, we can clear the list of points
        }
        private void SaveToBitmap()
        {
            if (points.Count == 0)
                return;
            using (Graphics g = Graphics.FromImage(bmp))
                g.DrawLines(pen, points.ToArray()); // Just draw current line on bitmap
        }
    }
