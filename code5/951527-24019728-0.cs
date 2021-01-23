    public partial class Form1 : Form
    {
        Bitmap _backbuffer;
        public Form1()
        {
            InitializeComponent();
            _backbuffer = new Bitmap(600, 400);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(_backbuffer))
            {
                //clear the backbuffer
                g.Clear(Color.White);
                //draw stuff for the next frame
                g.DrawEllipse(Pens.Black, new Rectangle(50, 50, 100, 100));
            }
            //draw the backbuffer to the screen
            pictureBox1.Image = _backbuffer;
        }
    }
