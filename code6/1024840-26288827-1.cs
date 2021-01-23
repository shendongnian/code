    private void timer1_Tick(object sender, EventArgs e)
    {
        span = span.Subtract(new TimeSpan(0, 0, 1));
        label21.Text = span.ToString(@"mm\:ss");
           
        if (span.TotalSeconds < 1)
        {
            span = new TimeSpan(0, numericUpDown1.Value, 0);
            fileDownloadRadar();
        }
    }
