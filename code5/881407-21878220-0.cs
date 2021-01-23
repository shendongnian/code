    public partial class Form1 : Form
    {
        static int px = 5, py = 5;
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
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            panel1.Refresh();
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            initilizeXY(e.X+offsetX, e.Y+offsetY);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel1_Paint(panel1, e);
        }
    }
