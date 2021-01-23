    private void DisplayImage()
    {
        PictureBox pictureBox1=new PictureBox();
        pictureBox1.Location=new Point(Use appropriate values to place the control);
        this.Controls.Add(pictureBox1);
        pictureBox1.Load("Path to a image to display");
    }
