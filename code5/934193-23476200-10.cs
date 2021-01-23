    // These are instance members outside any methods!!
    private int currentImageIndex = 0;
    string[] arr1 = new string[] { "water", "eat", "bath", "tv", "park", "sleep" };
    private void button1_Click(object sender, EventArgs e)
    {
        // EDIT: As per comments changed to turn the button into a Start/Stop button.
        //       When the button is pressed and the timer is stopped, the timer is started,
        //       otherwise it is started.
        // Stop the timer if it runs already
        if (timer.Enabled)
        {
            timer.Stop();
        }
        // Start the timer if it was stopped
        else
        {
            // Make the timer start right away
            currentImageIndex = 0;
            timer.Interval = 1;
            // Start the timer
            timer.Start();
        }
    }
