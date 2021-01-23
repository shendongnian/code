    while(pictureBox1.Top >= 20)
    {
        pictureBox1.Top--;
        System.Threading.Thread.Sleep(20);
        Invalidate();
        Refresh();
    }
    
    pictureBox1.Visible = false;
    pictureBox2.Visible = true;
