    private System.Threading.Timer timer;
    private void SetUpTimer(TimeSpan alertTime)
    {
         DateTime current = DateTime.Now;
         TimeSpan timeToGo = alertTime - current.TimeOfDay;
         if (timeToGo < TimeSpan.Zero)
         {
            return;//time already passed
         }
         this.timer = new System.Threading.Timer(x =>
         {
             this.ShowMessageToUser();
         }, null, timeToGo, Timeout.InfiniteTimeSpan);
    }
    private void ShowMessageToUser()
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new MethodInvoker(this.ShowMessageToUser));
        }
        else
        {
            MessageBox.Show("Your message");
        }
    }
