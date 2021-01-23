    public partial class Form1 : Form
    {
        private ImageList _imgList;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(Object sender, EventArgs e)
        {
            foreach (TabPage p in tabControl1.TabPages)
                p.Dispose();
            _imgList = new ImageList();
            _imgList.Images.Add("image0", Properties.Resources.ImageOne);
            _imgList.Images.Add("image1", Properties.Resources.ImageTwo);
            _imgList.Images.Add("image2", Properties.Resources.ImageThree);
            tabControl1.ImageList = _imgList;
        }
        private void button1_Click(Object sender, EventArgs e)
        {
            
            Int32 count = tabControl1.TabPages.Count;
            if (count < 3)
            {
                TabPage p = new TabPage();
                p.Name = "page" + count;
                p.Text = "page" + count;
                tabControl1.TabPages.Add(p);
                p.Parent = tabControl1;
                p.ImageKey = "image" + count;
            }
        }
    }
