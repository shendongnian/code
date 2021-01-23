    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var g = Graphics.FromImage(pictureBox1.Image);
            g.DrawEllipse(Pens.Blue, 10, 10, 100, 100);
            pictureBox1.Refresh();
        }
    }
