    public Form1()
    {
        InitializeComponent();
        pictureBox1.Click += pictureBox_Click;
        pictureBox2.Click += pictureBox_Click;
        pictureBox3.Click += pictureBox_Click;
        // ...
        pictureBox1.Tag = "picture1.png";
        pictureBox2.Tag = "picture2.png";
        pictureBox3.Tag = "picture3.png";
    }
    
    void pictureBox_Click(object sender, EventArgs e)
    {
        PictureBox pb = sender as PictureBox;
    
        if (pb.BackColor != Color.Black)
            Debug.WriteLine(pb.Tag.ToString());
        else
            Debug.WriteLine("Black image");
    
    }
