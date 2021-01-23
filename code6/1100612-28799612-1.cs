    private void button2_Click(object sender, EventArgs e)
    {
        // we pull the bitmap from the image
        Bitmap bmp = (Bitmap) pictureBox1.Image;
        // we change some picels
        for (int y = 100; y < bmp.Height; y++) 
        for (int x = 100; x < bmp.Width; x++)
        {
            Color c = bmp.GetPixel(x, y);
            bmp.SetPixel(x, y, Color.FromArgb(255, 255, c.G, c.B));
        }
        // we need to re-assign the changed bitmap
        pictureBox1.Image = (Bitmap) bmp;
    }
