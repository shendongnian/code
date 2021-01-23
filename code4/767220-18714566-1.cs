    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TestClass.defineMapArea(this);
        }
        public void pictureBox1_Paint(object sender, EventArgs e)
        {
        }
    }
