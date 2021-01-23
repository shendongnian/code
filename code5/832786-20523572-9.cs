    private void button1_Click(object sender, EventArgs e)
    {    
        // Create a threaded timer
        System.Timers.Timer animationTimer = new System.Timers.Timer();
        animationTimer.Interval = 20;
        animationTimer.AutoReset = false; // Only one Ping! We'll activate it if necessary
        animationTimer.Elapsed += new ElapsedEventHandler(AnimationStep);
        animationTimer.Start();
        // Disable the button also, because we don't want another timer instance to
        // interfere with our running animation
        button1.Enabled = false;
    }
