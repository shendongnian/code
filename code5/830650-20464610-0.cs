    private void Threaded_Click(object sender, EventArgs e)
    {
        const int outer = 1000;
        const int inner = 2;
    
        Stopwatch timer = Stopwatch.StartNew();
        Parallel.For(0, inner*outer, i=> {
        
            PerformOperation();
        });
        timer.Stop();
        TimeSpan timespan = timer.Elapsed;
    
        MessageBox.Show("Time Taken by " + (outer * inner) + " Operations: " +
            String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10),
            "Result",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
