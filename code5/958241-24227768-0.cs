    private void timer1_Tick(object sender, EventArgs e)
    {
        timer1.Enabled = false;
        if (listBox1.Items.Count > 0)
        {
            listBox1.Items.RemoveAt(0);
            progressBar1.Increment(1);
            groupBox1.Text = listBox1.Items.Count.ToString();
            timer1.Enabled = true;
        }
    }
