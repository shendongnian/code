    public struct MyPoint
    {
        public double X { set; get; }
        public double Y { set; get; }
        public PointF ToPoint()
        {
            return new PointF((float)X, (float)Y);
        }
    }
    /// <summary>
    /// For http://stackoverflow.com/questions/19459519/drawing-a-straight-line-from-points
    /// </summary>
    public partial class Form1 : Form
    {
        List<MyPoint> points;
        public Form1()
        {
            InitializeComponent();
            // Initialize points to draw
            points=new List<MyPoint>(100);
            for (int i=0; i<=100; i++)
            {
                double θ=2*Math.PI*(i/100.0);
                double x=(1+θ/Math.PI)*Math.Cos(θ);
                double y=(1+θ/Math.PI)*Math.Sin(θ);
                points.Add(new MyPoint() { X=x, Y=y });
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // smooth graphics
            e.Graphics.SmoothingMode=SmoothingMode.AntiAlias;            
            // set margins inside the control client area in pixels
            var margin=new System.Drawing.Printing.Margins(16, 16, 16, 16);
            // set the domain of (x,y) values
            var range=new RectangleF(-3, -3, 6, 6);
            // scale graphics
            ScaleGraphics(e.Graphics, pictureBox1, range, margin);            
            // convert points to pixels
            PointF[] pixels=points.Select((v) => v.ToPoint()).ToArray();
            // draw arrow axes
            using (var pen=new Pen(Color.Black, 0))
            {
                pen.EndCap=System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                e.Graphics.DrawLine(pen, range.Left, 0.0f, range.Right, 0.0f);
                e.Graphics.DrawLine(pen, 0.0f, range.Top, 0.0f, range.Bottom);
            }
            // draw bounding rectangle (on margin)
            using (var pen=new Pen(Color.LightGray, 0))
            {
                pen.DashStyle=DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, Rectangle.Round(range));
            }
            // draw curve
            using (var pen = new Pen(Color.Blue, 0))
            {                
                //e.Graphics.DrawLines(pen, pixels);
                e.Graphics.DrawCurve(pen, pixels);
            }            
        }
        /// <summary>
        /// Scales the Graphics to fit a Control, given a domain of x,y values and side margins in pixels
        /// </summary>
        /// <param name="g">The Graphics object</param>
        /// <param name="control">The Control</param>
        /// <param name="domain">The value domain</param>
        /// <param name="margin">The margin</param>
        void ScaleGraphics(Graphics g, Control control, RectangleF domain, Margins margin)
        {
            // Find the drawable area in pixels (control-margins)
            int W=control.Width-margin.Left-margin.Right;
            int H=control.Height-margin.Bottom-margin.Top;
            // Ensure drawable area is at least 1 pixel wide
            W=Math.Max(1, W);
            H=Math.Max(1, H);
            // Find the origin (0,0) in pixels
            float OX=margin.Left-W*(domain.Left/domain.Width);
            float OY=margin.Top+H*(1+domain.Top/domain.Height);
            // Find the scale to fit the control
            float SX=W/domain.Width;
            float SY=H/domain.Height;
            // Transform the Graphics
            g.TranslateTransform(OX, OY);
            g.ScaleTransform(SX, -SY);
        }
        
        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            // redraw on resize
            pictureBox1.Refresh();
        }
    }
