    public partial class Form1 : Form
    {
        static int px = 5, py = 5;
        static int p2x = 0, p2y = 0;
        int offsetX;
        int offsetY;
    
        public Form1()
        {
            InitializeComponent();
            offsetX = panel2.Location.X - panel1.Location.X;
            offsetY = panel2.Location.Y - panel1.Location.Y;
        }
    
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Red, 5, 5, px, py);
        }
    
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            initilizeXY(e.X, e.Y);
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    
        private void initilizeXY(int pxx, int pyy)
        {
            px = pxx;
            py = pyy;
        }
    
        private void initilizeXY2(int pxx, int pyy)
        {
            p2x = pxx;
            p2y = pyy;
        }
    
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            panel1.Refresh();
            panel2.Refresh();
        }
    
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            initilizeXY(e.X+offsetX, e.Y+offsetY);
            initilizeXY2(e.X, e.Y);
        }
    
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (px > offsetX && py > offsetY)
            {
                int p2start = findIntersectFromLineEquation(new Point(5, 5), new Point(px, py));
    
                e.Graphics.DrawLine(Pens.Red, 0, p2start - offsetY, p2x, p2y);
            }
        }
    
        private int findIntersectFromLineEquation(Point start, Point end)
        {
            if (start.X == end.X || start.Y == end.Y)
                return 0;
    
            double a = (double)(end.Y - start.Y) / (double)(end.X - start.X);
            double b = (double)(start.Y) - (double)(a * start.X);
    
            return (int)(a * offsetX + b);
        }
    }
