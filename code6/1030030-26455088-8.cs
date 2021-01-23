    Bitmap bmp;
    float angle = 0f;
    private void Form1_Load(object sender, EventArgs e)
    {
        bmp = new Bitmap(yourGrarImage);
        int dpi = 96;
        using (Graphics G = this.CreateGraphics()) dpi = (int)G.DpiX;
        bmp.SetResolution(dpi, dpi);
        panel1.ClientSize = bmp.Size;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        angle+=2;              // set the speed here..
        angle = angle % 360;
        panel2.Invalidate();
    }
            
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        if (bmp!= null) 
        {
                float bw2 = bmp.Width / 2f;    // really ought..
                float bh2 = bmp.Height / 2f;   // to be equal!!!
                e.Graphics.TranslateTransform(bw2, bh2);
                e.Graphics.RotateTransform(angle);
                e.Graphics.TranslateTransform(-bw2, -bh2);
                e.Graphics.DrawImage(bmp, 0, 0);  
                e.Graphics.ResetTransform();
        }
    }
    private void panel1_MouseLeave(object sender, EventArgs e)
    {
        timer1.Stop();
    }
    private void panel1_MouseHover(object sender, EventArgs e)
    {
        timer1.Start();
        timer1.Interval = 10;    // ..and/or here
    }
