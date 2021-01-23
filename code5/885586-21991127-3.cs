    private async void button1_Click(object sender, EventArgs e)
    {
        Graphics g = panel1.CreateGraphics();
        Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
        panel1.BackgroundImage = (Image)bmp;
        panel1.BackgroundImageLayout = ImageLayout.None;
        bmp.SetPixel(15, 15, Color.Red);
        await Task.Delay(5000); // <---
        bmp.SetPixel(17, 17, Color.Red);
    }
