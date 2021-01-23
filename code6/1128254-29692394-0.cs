    private void button1_Click(object sender, EventArgs e)
    {
        // To keep the user from repeatedly pressing the button, let's disable it
        button1.Enabled = false;
        // Capture the current text ("ABC" in your example)
        string originalText = label1.Text;
               
        // Create a background worker to sleep for 2 seconds...
        var backgroundWorker = new BackgroundWorker();
        backgroundWorker.DoWork += (s, ea) => Thread.Sleep(TimeSpan.FromSeconds(2));
        // ...and then set the text back to the original when the sleep is done
        // (also, re-enable the button)
        backgroundWorker.RunWorkerCompleted += (s, ea) =>
        {
            label1.Text = originalText;
            button1.Enabled = true;
        };
        // Set the new text ("CDE" in your example)
        label1.Text = "CDE";
        // Start the background worker
        backgroundWorker.RunWorkerAsync();
    }
