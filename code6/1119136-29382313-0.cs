    static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    
    void TimerInit(int interval) {
        myTimer.Tick += new EventHandler(myTimer_Tick); //this is run every interval
        myTimer.Interval = internal;
        myTimer.Enabled = true;
        myTimer.Start(); 
    }
    
    private static void myTimer_Tick(object sender, EventArgs e) {
        System.IO.File.WriteAllText(@"c:\path.txt", jointAngles); //You might want to append
        if (reached 5 minutes or X write cycles) {
            myTimer.Stop();
        }
    }
