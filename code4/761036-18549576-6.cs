Drop a Timer on your Form.
Set its Interval property to 5000 Milliseconds.
Create a new Event for its Tick Event (locate Tick event in Events Window and double click it).
Next modify DisplayImage() so it looks like :
    private void DisplayImage()
    {
        timer1.Start();
        PictureBox pictureBox1=new PictureBox();
        pictureBox1.Location=new Point(Use appropriate values to place the control);
        this.Controls.Add(pictureBox1);
        pictureBox1.Load("Path to a image to display");
    }
Next define an integer field(outside all functions) named count,like this;
    private int count=0;
Now modify timer1_Tick() event so it looks like below;
    private void timer1_Tick(object sender, EventArgs e)
    {
        count++;
        if (count == 5)
        {
            SourcePictureBox.Image = null;
            count = 0;
        }
    }
