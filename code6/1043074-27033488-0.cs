    using System.Theading;
    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
    int[] foo()
    {
      int numberOfIterations = interval time * number of intervals; // initialize this to the proper number of times to decrement the counter. If we are decrementing every 1000 ms
      CountdownEvent countDown = new CountdownEvemt(numberOfIterations);
      do_something1();
      int[] some_value;
  
      timer1.Interval = 1000;
      timer1.Tick += new EventHandler(delegate(object o, EventArgs ea)
      {
          if (browser.ReadyState == WebBrowserReadyState.Complete)
          {
              timer1.Stop();
              baa(some_value);
              // since this seems where you want to shut down the method we need to trigger the countdown
              int countLeft = countDown.CurrentCount;
              countDown.Signal(countLeft); 
          } else {
              if(countDown.CurrentCount - 1 == 0) {
                  countDown.Reset(); // we don't want to finish yet since we haven't reached the proper end condition so reset the counter
              }
              countDown.Signal(); // will decrement the counter
          }
      });
      timer1.Start();
   
      countDown.Wait(); // will wait 'til the counter is at 0 before continuing
       return some_value;
