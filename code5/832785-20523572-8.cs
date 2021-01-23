    private void button1_Click(object sender, EventArgs e)
    {
        while (pictureBox1.Top >= 20)
        {
            pictureBox1.Top = pictureBox1.Top - 1;
            this.Invalidate();
            this.Refresh();
            System.Threading.Thread.Sleep(20);
        }
    
        // Here you KNOW that the picture box is at y-position 20, so there's not need
        // for the IF
        pictureBox1.Visible = false;
        pictureBox2.Visible = true;
    }
