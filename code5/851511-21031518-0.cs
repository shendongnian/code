    public Form1()
    {
        InitializeComponent();
        pictureBox1.Click += pictureBox_Click;
        pictureBox2.Click += pictureBox_Click;
        pictureBox3.Click += pictureBox_Click;
        // ...
    }
    
    void pictureBox_Click(object sender, EventArgs e)
    {
        PictureBox pb = sender as PictureBox;
    
        if (pb.BackColor != Color.Black)
            Debug.WriteLine(pb.Tag.ToString());
        else
            Debug.WriteLine("Black image");
    
    }
