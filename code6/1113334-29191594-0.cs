    private void timer1_Tick(object sender, EventArgs e)
    {
        counter--;
        if (counter == 0)
        {
            timer1.Stop();
            label1.Text = counter.ToString(); // *** Look here
            MessageBox.Show("Time's Up!!");
        }
    }
