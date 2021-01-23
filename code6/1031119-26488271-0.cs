    long lastDownload = 0;
    long bytesIn = 0
    
    //This is a event for a timer that fires once per second on the UI thread.
    private void TimerTick(object sender, EventArgs e)
    {
         //Figure out how many bytes where downloaded in the last second.
         var bytesDownloadedLastSecond = bytesIn - lastsDownload;
         //Copy the number over for the next firing of TimerTick.
         lastDownload = bytesIn;
         double scalingFactor;    
         string formatText;
    
         //Figure out if we should display in bytes, kilobytes or megabytes per second.
         if(bytesDownloadedLastSecond < 1024)
         {
              formatText = "{0:N0} B/sec";
              scalingFactor = 1;
         }
         else if(bytesDownloadedLastSecond < 1024 * 1024)
         {
              formatText = "{0:N2} Kb/sec";
              scalingFactor = 1024;
         }
         else
         {
              formatText = "{0:N2} Mb/sec";
              scalingFactor = 1024 * 1024;
         }
    
         //Display the speed to the user, scaled to the correct size.
         speedTextBox.Text = String.Format(formatText, bytesDownloadedLastSecond / scalingFactor );
    }
    
    private void DownloadProgress(object sender, EventArgs e)
    {
        bytesIn = int.Parse(e.BytesReceived.ToString());
        totalBytes = int.Parse(e.TotalBytesToReceive.ToString());
    }
