    void timer1_Tick(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.RemoveAt(0);
                progressBar1.PerformStep();
                groupBox1.Text = listBox1.Items.Count.ToString();
            }
            else
            {
                this.timer1.Enabled = false;
            }
        }
