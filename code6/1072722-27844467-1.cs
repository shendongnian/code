    int Count = 0;
    ...
    private void Counter(object sender, EventArgs e)
    {
    Count++;
    }
    ...
    private void AnimateKey(int Start, int Stop)
     {
         myTimer.Interval = 5;
         myTimer.Tick += new EventHandler(myTimer_Tick);
         myTimer.Tick += new EventHandler(Counter);
         myTimer.Enabled = true;
         myTimer.Start();
         while(Count!=100);
         myTimer.Stop();
     }
