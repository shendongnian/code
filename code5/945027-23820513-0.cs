    timer1.Interval = 1;
    
    private void NewsUpdate()
    {
        newText = new List<string>();
        counter += 1;
        TimeSpan t = TimeSpan.FromMilliseconds(counter);
    
        string time = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                      t.Hours,
                      t.Minutes,
                      t.Seconds,
                      t.Milliseconds);
        progressBar1.Value = Convert.ToInt32(counter / 1000);
        label9.Text = time;
    }
