    public partial class Form1 : Form
    {
        private int x, y;
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            MouseMove += Form1_MouseMove;
        }
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
                    e.Graphics.DrawImage(AppName.Properties.Resources.ImageName, coltz);
                }
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            Invalidate();
        }
    }
