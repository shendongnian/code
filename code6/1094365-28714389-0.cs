    public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            MouseMove += Form1_MouseMove;
            MouseDown += Form1_MouseMove;
        }
        
        private int x,y;
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e);
        }
        private void Draw(PaintEventArgs e)
        {
            if (MouseButtons == System.Windows.Forms.MouseButtons.Left)
            {
                if (x < 301 && x > 24 && y < 301 && y > 24)
                {
                    PointF coltz = new PointF(x / 25 * 25, y / 25 * 25);
                    e.Graphics.DrawImage(battleships.Properties.Resources.yellow4, coltz);
                }
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g;
            g = e.Graphics;
            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            for (int i = 25; i <= 300; i = i + 25)
            {
                g.DrawLine(pen, i, 25, i, 300);
                g.DrawLine(pen, 25, i, 300, i);
            }
        }
    }
