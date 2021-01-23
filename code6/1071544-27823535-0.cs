    public partial class Form1 : Form
    {
        private Random R = new Random();
        private IEnumerator<Image> images;
        private List<Image> list = new List<Image>();
        private System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();
   
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // ...populate "list" somehow ...
            String PicturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            foreach(String PictureFile in System.IO.Directory.GetFiles(PicturesPath, @"*.png"))
            {
                list.Add(new Bitmap(PictureFile));
            }
            aTimer.Interval = R.Next(3000, 10001); // 3 to 10 second interval
            aTimer.Tick += aTimer_Tick;
            aTimer.Start();
            ChangeImages();
        }
        private void ChangeImages()
        {
            pictureBox1.Image = NextImage();
            pictureBox2.Image = NextImage();
        }
        private Image NextImage()
        {
            if (images == null && list.Count > 0)
            {
                images = list.GetEnumerator();
            }
            if (images != null)
            {
                if (!images.MoveNext())
                {
                    images.Reset();
                    images.MoveNext();
                }
                return images.Current;
            }
            else
            {
                return null;
            }
        }
        private void aTimer_Tick(object sender, EventArgs e)
        {
            // change the Interval:
            aTimer.Interval = R.Next(3000, 10001); // 3 to 10 second interval
            ChangeImages();
        }
    }
