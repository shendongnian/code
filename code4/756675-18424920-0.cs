    public partial class Form1 : Form
    {
        bool mouseIsDown;
        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button== System.Windows.Forms.MouseButtons.Right)
                mouseIsDown = true;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                Point point = panel1.PointToClient(Cursor.Position);
                DrawPoint((point.X), (point.Y), Color.Navy);
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }
        public void DrawPoint(int x, int y, Color color)
        {
            Graphics g = this.panel1.CreateGraphics();
            Pen pen = new Pen(color);
            g.DrawRectangle(pen, x, y, 3, 3);
        }
    }
