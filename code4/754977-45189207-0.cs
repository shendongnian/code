    private void WaitNSeconds(int seconds)
    {
        if (seconds < 1) return;
        DateTime _desired = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < _desired) {
             Thread.Sleep(1);
             System.Windows.Forms.Application.DoEvents();
        }
    }
