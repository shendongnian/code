    public Form1()
    {
        InitializeComponent();
        this.myPictureBox.BackColor = Color.Red;
    }
    
    private void startButton_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show(
            "Please click the object in the image ",
            "", 
            MessageBoxButtons.OKCancel, 
            MessageBoxIcon.Exclamation, 
            MessageBoxDefaultButton.Button1) == DialogResult.OK)
        {
            this.myPictureBox.MouseClick += this.myPictureBox_MouseClick;
        }
    }
    
    void myPictureBox_MouseClick(object sender, MouseEventArgs e)
    {
        this.myPictureBox.MouseClick -= myPictureBox_MouseClick;
        var point = new Point(e.X, e.Y);
        MessageBox.Show(string.Format("You've selected a pixel with coordinates: {0}:{1}", point.X, point.Y));
    }
