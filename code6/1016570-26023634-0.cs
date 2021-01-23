    private void Form1_Load(object sender, EventArgs e)
    {
        var pictureBox1 = new PictureBox
        {
            BackColor = Color.Black,
            ImageLocation = @"C:\Users\xoswaldr\Desktop\OrangeLogo.jpg",
            Location = new Point(20, 40),
            Name = "pictureBox1",
            Size = new Size(100, 50)
        };
    
        this.Controls.Add(pictureBox1);
    
        pictureBox1.BringToFront();
    }
