    private void timer_Tick(object sender, EventArgs e)
    {
         var timer = (Timer)sender;
         timer.Stop();
          
         //you should check how many time's you have fired and decide whether to keep going here.
         timer.Interval = valueTimer.Next(10, 100);
         timer.Start();
    }
    private void btnRun_Click(object sender, EventArgs e)
    {
        timer.Interval = valueTimer.Next(10, 100);
        timer1.Start();
    }
