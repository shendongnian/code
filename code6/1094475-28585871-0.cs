    public partial class Form1 : Form
    {
        private ImageList imagelst;
        
        public Form1()
        {
            InitializeComponent();
            imagelst = new ImageList();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //pictures from your Harddrive
            Image i = new Bitmap("rock.jpg");
            imagelst.Images.Add("rock", i);
            i = new Bitmap("scissors.jpg");
            imagelst.Images.Add("scissors", i);
            i = new Bitmap("paper.jpg");
            imagelst.Images.Add("paper", i);
        }
        private void btnRock_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imagelst.Images["rock"];
        }
        private void btnScissors_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imagelst.Images["scissors"];
        }
        private void btnPaper_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imagelst.Images["paper"];
        }
    }
