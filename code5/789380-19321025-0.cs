    private void Form1_MouseWheel(object sender, MouseEventArgs e)
    {
        if (e.Delta > 0) //moved forward
        {
            timer1.Interval += 1000;
        }
        else //moved backword
        {
            timer1.Interval -= 1000;
        }
    }
