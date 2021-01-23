     WaitHandle[] waitFor = new WaitHandle[]{stopEvent, pauseEvent};
     int trigger = -1;
     bool keepGoing = true;
     while(keepGoing)
     {
         trigger = WaitHandle.WaitAny(waitFor, TimeSpan.FromSeconds(30));
         switch (trigger) {
             case WaitHandle.WaitTimeout:
                The main body of the loop goes here
                break;
             case 0: // stop
                 keepGoing = false;
                 break;
             case 1: // pause
                 System.Diagnostics.Debug.Write("Paused - ");
                 System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString());
                 break;
         }
