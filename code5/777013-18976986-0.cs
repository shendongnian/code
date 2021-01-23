    System.Windows.Forms.Timer _delayTimer = new System.Windows.Forms.Timer();
    _delayTimer.Interval = 1000;
    _delayTimer.Tick += new EventHandler(_delayTimer_Tick);
     void _delayTimer_Tick(object sender, EventArgs e)
     {
         _delayTimer.Stop();
         //call your update logic here
     }
