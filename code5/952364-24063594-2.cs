    private void button3_MouseEnter(object sender, EventArgs e)
    {
        timer1.Interval = 25;
        timer1.Start();
    }
    private void button3_MouseLeave(object sender, EventArgs e)
    {
        timer1.Stop();
        button3.ImageIndex = 0;
        index = 1;
    }
    int index = 1;
    private void timer1_Tick(object sender, EventArgs e)
    {
        index++; ;
        button3.ImageIndex = index;
        if (index >= imageList1.Images.Count)
        { timer1.Stop(); button3.ImageIndex = 1; index = 1; }
    }
