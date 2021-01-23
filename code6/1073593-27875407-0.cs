    private Image img;
    public Form1()
    {
        InitializeComponent();
        img = Image.FromFile(@"C:\Users\Administrator\TEST C#\TEST2frame2\chef.gif");
        pictureBox1.Image = img;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        var dim = new FrameDimension(img.FrameDimensionsList[0]);
        img.SelectActiveFrame(dim, 1);
        pictureBox1.Enabled = false;
    }
