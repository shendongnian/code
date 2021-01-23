    public partial class Form1 : Form
    {        
        List<Point> ballList = new List<Point>();        
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {           
            ballList.Add(e.Location);
            pictureBox1.Refresh();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Point pBall in ballList)
            {
                e.Graphics.FillEllipse(Brushes.Blue, pBall.X, pBall.Y, 20, 20);
            }
        }
    }
