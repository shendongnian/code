    private void button2_Click(object sender, EventArgs e)
    {
        Bitmap bmp1 = new Bitmap("D:\\fineline.png");
        pictureBox1.Image = bmp1;
        Bitmap bmp2 = (Bitmap)bmp1.Clone();
        bmp2.MakeTransparent(bmp2.GetPixel(0, 0));
        Bitmap bmp3 = (Bitmap)bmp2.Clone();
        using (Graphics G = Graphics.FromImage(bmp3))
        {
            G.CompositingMode = CompositingMode.SourceOver;
            G.CompositingQuality = CompositingQuality.HighQuality;
            G.DrawImage(bmp2, 0, 1);
            G.DrawImage(bmp2, 1, 1);
            G.DrawImage(bmp2, 1, 0);
        }
        pictureBox2.Image = bmp3;
        Bitmap bmp4 = new Bitmap(bmp3.Width / 2, bmp3.Height / 2);
        using (Graphics G = Graphics.FromImage(bmp4))
        {
            G.Clear(bmp1.GetPixel(0, 0));
            G.DrawImage(bmp3, 0, 0, bmp4.Width, bmp4.Height);
        }
        pictureBox3.Image = bmp4;
    }
