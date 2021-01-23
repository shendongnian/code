    private void Form2_Paint(object sender, PaintEventArgs e)
    {
        Rectangle R1 = new Rectangle(11, 11, 222, 111);
        Rectangle R2 = new Rectangle(44, 44, 111, 55);
        GraphicsPath GP1 = new GraphicsPath();
        GraphicsPath GP2 = new GraphicsPath();
        GP1.AddEllipse(R1);
        GP2.AddEllipse(R2);
        Region Re1 = new Region(GP1);
        Region Re2 = new Region(GP2);
        Re1.Exclude(Re2);           // subtract the inner region
        e.Graphics.Clip = Re1;      // restrict the Graphics to the region
        e.Graphics.Clear(Color.DarkOrange);
        e.Graphics.ResetClip();    // maybe reset the clip
    }
