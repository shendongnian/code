    public partial class Form1 : Form
    {
        spielfeld Feld = new spielfeld();
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            //pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Feld.spielfeldnullsetzen();
            Feld.spielfeldol(pictureBox1);
        }
        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    Feld.spielfeldol(pictureBox1);
        //}
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int eX = e.X;
            int eY = e.Y;
            //Feld.spielfeldol(pictureBox1);
            Feld.mouseclick(eX, eY, pictureBox1);
        }
    }
