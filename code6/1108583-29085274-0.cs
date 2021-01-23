    public partial class UCTextWithImage : UserControl
    {
        public event EventHandler TextClick;
        public event EventHandler ImgClick;
    
        public UCTextWithImage()
        {
            InitializeComponent();
        }
    
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ImgClick != null)
                ImgClick(sender, e);
        }
    
        private void label1_Click(object sender, EventArgs e)
        {
            if (TextClick != null)
                TextClick(sender, e);
        }
    }
