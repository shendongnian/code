    private System.Timers.Timer timer2 = new System.Timers.Timer(1000),
                                timer3 = new System.Timers.Timer(10);
    public void Init()
    {
        timer3.Elapsed += (sender, args) =>
        {
            // update your UI from the timer's thread
            pictureBox1.Invoke(
                new Action( 
                    () =>
                    {
                        pictureBox1.Invalidate();
                    }
                )
            );
        };
        timer2.Elapsed += (sender, args) =>
        {
            // Do other stuff with the UI by calling 
            // the appropriate Control invoke methods
        };
        timer2.Enabled = timer3.Enabled = true;
    }
