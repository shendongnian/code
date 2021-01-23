    Random R = new Random();
    private void button1_Click(object sender, EventArgs e)
    {
        panel1.AutoScroll = true;
        pictureBox1.Parent = panel1;
        pictureBox1.Location = Point.Empty;
        pictureBox1.Image = new Bitmap(3000, 500);
        pictureBox1.ClientSize = pictureBox1.Image.Size;
        var imgFiles = Directory.GetFiles(@"D:\scrape\", "*.png");
        int counter = 0;
        foreach(string file in imgFiles)
        {
            using (Graphics G = Graphics.FromImage(pictureBox1.Image))
            using (Bitmap bmp = new Bitmap(file))
            {
                if (bmp.Size.Width < 300)
                {
                    for (int i = 0; i < 10; i++ )
                        G.DrawImage(bmp, R.Next(2500), R.Next(400));
                }
            }
        }
    }
