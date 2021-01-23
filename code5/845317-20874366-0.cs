    private void Form1_Load(object sender, EventArgs e)
    {
        pictureBox3.Click += HandleColorPick;
        pictureBox4.Click += HandleColorPick;
        pictureBox5.Click += HandleColorPick;
        pictureBox6.Click += HandleColorPick;
        pictureBox7.Click += HandleColorPick;
        pictureBox8.Click += HandleColorPick;
        pictureBox9.Click += HandleColorPick;
    }
    private void HandleColorPick(object sender, EventArgs e)
    {
        var s =(PictureBox) sender;
        MessageBox.Show(s.BackColor.ToString());
    }
