    private DateTime lastUploadActivityTime = DateTime.Now;
    private void HttpSendProgress(object sender, HttpProgressEventArgs e)
    {
        // update variable
        lock (lastUploadActivityTime)
        {
           lastUploadActivityTime = DateTime.Now;
        }
    }
    // this method is executed in different thread, than method above
    private void ThreadCheckAvailableTargetSite()
    {
        while (boolThreadAvailableTargetSiteActive)
        {
            lock (lastUploadActivityTime)
            {
               if (lastUploadActivityTime.AddSeconds(5) <= DateTime.Now)
               {
                   MessageBox.Show("BREAK");
                   boolThreadAvailableTargetSiteActive = false;
               }
            }
            Thread.Sleep(500);
        }
    }
