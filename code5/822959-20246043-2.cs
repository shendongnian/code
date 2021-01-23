    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            center = new PointF(startOffset+r, r + 30);
            t.Interval = 1;
            t.Tick += (se, e) =>
            {
                if (s >= ClientSize.Width - r*2 - startOffset) dir = -1;
                else if (s <= startOffset) dir = 1;                
                center.X += dir * step;
                Invalidate();
            };
            t.Start();
            DoubleBuffered = true; 
            Paint += Form1_Paint;           
        }
        Timer t = new Timer();
        PointF center;
        int r = 130;
        float s;
        float step = 1f;
        int dir = 1;
        int startOffset;        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            s += step * dir;                        
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Wheel(s, e.Graphics);                        
            e.Graphics.FillEllipse(Brushes.Green, 
                              new RectangleF(center.X - r, center.Y - r, r * 2, r * 2));
            //draw this line to see how the wheel runs
            e.Graphics.DrawLine(Pens.Red, new PointF(center.X - r, center.Y), 
                                          new PointF(center.X + r, center.Y));
        }        
        public void Wheel(float dx, Graphics g)
        {            
            float f = (float)(dx * 180 / (r * Math.PI));
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(f);
            g.TranslateTransform(-center.X, -center.Y);            
        }
    }
