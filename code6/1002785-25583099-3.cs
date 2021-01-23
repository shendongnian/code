    public partial class Form1 : Form
    {
        Paintballs pBalls = new Paintballs();
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            pBalls.Add(e.Location);
            pictureBox1.Refresh();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pBalls.Paint(e.Graphics);
        }
    }
