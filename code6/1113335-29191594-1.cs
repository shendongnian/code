    private void timer1_Tick(object sender, EventArgs e)
    {
        counter--;
        label1.Text = counter.ToString(); // should work
        if (counter == 0)
        {
            timer1.Stop();
            MessageBox.Show("Time's Up!!");
        }
    }
