    private DateTime start; // Set this with DateTime.UtcNow when starting the timer
    void timer_Tick(object sender, EventArgs e)
    {
        // Compute the new timespan
        var timespan = DateTime.UtcNow - start;
        // Do whatever with it (check if it's greater than 4 seconds, display it, ...)
    }
