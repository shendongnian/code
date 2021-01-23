    private void button2_Click(object sender, EventArgs e)
    {
        Bitmap bmp = new Bitmap((int)numericUpDown1.Value, (int)numericUpDown2.Value);
        using (Graphics G = Graphics.FromImage(bmp))
        {
            bmp.SetPixel(0, 0, Color.Black);
        }
        if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
        pictureBox1.BackgroundImage = bmp;
        pictureBox1.BackgroundImageLayout = ImageLayout.Tile;
    }
