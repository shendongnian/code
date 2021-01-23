    System.Timers.Timer timer1 = new System.Timers.Timer();
    void foo() {    
        timer1.Interval = 1000;
        timer1.Elapsed += new ElapsedEventHandler(timerTick);
    
        //This assumes that the class `foo` is in is a System.Forms class. Makes the callback happen on the UI thread.
        timer1.SynchronizingObject = this;
    
        //Tells it to not restart when it finishes.
        timer1.AutoReset = false;
    
        timer1.Start();
    }
    
     void timerTick(object o, ElapsedEventArgs ea)
     {
         if (browser.ReadyState == WebBrowserReadyState.Complete)
         {
             MessageBox.Show("stop it!");
         }
     }
