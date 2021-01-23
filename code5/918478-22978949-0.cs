    public static void methodA()
    {
        var bgw = new BackgroundWorker();
        bgw.DoWork += worker_Dowork;
        bgw.RunWorkerCompleted += worker_RunWorkerCompleted;
        
        if (Utilities.isInternet())
        {
            bgw.RunWorkerAsync();
        }
    }
    
    static void worker_Dowork(object sender, DoWorkEventArgs e)
    {
        // Your code goes here
    }
    
    static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    
    }
