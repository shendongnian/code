    System.Timers.Timer _delayTimer = new System.Timers.Timer(1000);
    _delayTimer.Elapsed += new EventHandler(_delayTimer_Elapsed);
     void _delayTimer_Elapsed(object sender, EventArgs e)
     {
         _delayTimer.Stop();
         //call your update logic here
     }
