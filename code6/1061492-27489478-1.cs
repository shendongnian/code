    private void timer1_Tick(object sender, EventArgs e)
        {
            if (tbScan.Text.Length == 8)
            {
                timer1.Stop();
                MessageBox.Show("8 tekens zijn ingevoerd!");
            }
        }
