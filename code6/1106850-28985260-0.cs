    private void timer1_Tick(object sender, EventArgs e)
    {
        index++;
        millisecondi++;
        timer1.Stop();
        if (millisecondi == 1000)
        {
            progressBar1.Value = progressBar1.Value - 1;
    
            if (progressBar1.Value <= 0)
            {
                MessageBox.Show("Sei Morto");
            }
        }
        else
        {
            timer1.Start(); // will 'retick' if millisecondi != 1000
        }
    }
