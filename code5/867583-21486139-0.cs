    DateTime LastMessageSentOn;
    //Initialize it in constructor or anywhere else before using.
    void activityWorker_Tick(object sender, EventArgs e)
    {
        bool checkIdle = (User32Interop.GetLastInput() > activityThreshold);
        if (isIdle != checkIdle)
        {
            if (checkIdle && LastMessageSentOn.AddMintues(1)<DateTime.Now)
            {
                System.Windows.Forms.MessageBox.Show("Idle: " + count);
                LastMessageSentOn = DateTime.Now;
                count++;
            }
            isIdle = checkIdle;
        }
    }
