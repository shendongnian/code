    private void timer3_Tick(object sender, EventArgs e)
    {
        timer3.Enabled = false;
        if (listBox1.Items.Count > 0)
        {
            listBox1.Items.RemoveAt(0);
            progressBar1.Increment(1);
            groupBox2.Text = listBox1.Items.Count.ToString();
            timer3.Enabled = true;
        }
        else
        {
            MessageBox.Show("The list box is clear.");
        }
    } 
