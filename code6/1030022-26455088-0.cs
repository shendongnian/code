    Bitmap bmp;
    float angle = 0f;
    private void Form1_Load(object sender, EventArgs e)
    {
        bmp = new Bitmap(yourGrarImage);
        panel1.ClientSize = bmp.Size;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        angle+=2;  // set the speed..
        angle = angle % 360;
        panel2.Invalidate();
        label1.Text = angle.ToString();
    }
            
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        if (bmp!= null) {
            if (angle == 0) e.Graphics.DrawImage(bmp, 0, 0);
            else
            {
                float bw2 = bmp.Width / 2f;
                float bh2 = bmp.Height / 2f;
                e.Graphics.TranslateTransform(bw2, bh2);
                e.Graphics.RotateTransform(angle);
                e.Graphics.TranslateTransform(-bw2, -bh2);
                e.Graphics.DrawImage(bmp, 0, 0);  
                e.Graphics.ResetTransform();
            }
        }
    }
    private void panel1_MouseLeave(object sender, EventArgs e)
    {
        timer1.Stop();
    }
    private void panel1_MouseHover(object sender, EventArgs e)
    {
        timer1.Start();
        timer1.Interval = 10;  // .. and/or here
    }
