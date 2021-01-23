    private void pictureBox1_Click(object sender, EventArgs e)
    {
        PictureBox flower1 = new PictureBox();
        flower1.Image = pictureBox1.Image;
        flower1.Location = Point.Empty;
        flower1.Width = 100;
        flower1.Parent = panel1;
        flower1.MouseDown += new MouseEventHandler(flower1_MouseDown);
    }
