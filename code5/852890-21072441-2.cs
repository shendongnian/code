    private bool isPlayingSounds;
    private int index;
    private List<String> websites;
    private Timer myTimer;
    private void Form1_Load()
    {
        myTimer = new System.Windows.Forms.Timer();
        myTimer.Interval = 7000;
        myTimer.Tick += new EventHandler(myTimer_Tick);
    }
    public void PlaySounds(List<String> websites)
    {
        if (isPlayingSounds)
        {
            // Already playing.
            // Throw exception here, or stop and play new website collection. 
        }
        else
        {
            isPlayingSounds = true;
            this.websites = websites;
            PlayNextSound();
        }
    } 
    private void PlayNextSound()
    {
        if (index < websites.Count)
        {
            webBrowser.Navigate(Uri.EscapeDataString(websites[index]));
            myTimer.Start();
    
            // Prepare for next website, if any. 
            index++;
        }
        else
        {
            // Remove reference to object supplied by caller
            websites = null;
            / Reset index for next call to PlaySounds.
            index = 0;
            // Reset flag to indicate not playing. 
            isPlayingSounds = false;
        }
    }
    private void myTimer_Tick(object sender, EventArgs e)
    {
        myTimer.Stop();
        PlayNextSound();
    }
