    private void Form1_SizeChanged(object sender, EventArgs e)
    {
        if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
        pictureBox1.Image = ResizeBitmap(image1, pictureBox1.Width, pictureBox1.Height);
        if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
        pictureBox2.Image = ResizeBitmap(image2, pictureBox2.Width, pictureBox2.Height);
    }
