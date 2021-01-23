    public partial class Form1 : Form
    {
        private int RectSideLen = 15;
        private IList<Rectangle> DrawBuffer = new List<Rectangle>();
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int cornerOffset = RectSideLen / 2;
            
            Point newUpLeftCorner = e.Location;
            newUpLeftCorner.Offset(-cornerOffset, -cornerOffset);
            DrawBuffer.Add(new Rectangle(newUpLeftCorner, new Size(RectSideLen, RectSideLen)));
            pictureBox1.Refresh();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Red, 1))
            {
                foreach (Rectangle r in DrawBuffer)
                {
                    e.Graphics.DrawRectangle(pen, r);
                }
            }
        }
    }
