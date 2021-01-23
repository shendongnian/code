    // Build stopwatch and lists
    Stopwatch sw = new Stopwatch();
    List<string> startTimes = new List<string>();
    List<string> endTimes = new List<string>();
    private void startBtn_Click(object sender, EventArgs e)
    {
        // Start stopwatch and record start time
        sw.Start();
        startTimes.Add(DateTime.Now.ToString("h.mm"));
    }
    private void stopBtn_Click(object sender, EventArgs e)
    {
        // Stop stopwatch
        sw.Stop();
        // Record stop time and reset stopwatch
        endTimes.Add(DateTime.Now.ToString("h.mm"));
        sw.Reset();
        // Output timespan
        outputLbl.Text = sw.Elapsed.ToString();
    }
