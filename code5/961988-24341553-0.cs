    // This should be declared at your class level and it should be a static field/property
    AutoReset autoReset = new AutoResetEvent(false);
    
    // Only one thread will be able to reach the code within this if statement.
    // You decide if you want to provide a timeout or you want to wait forever,
    // and all threads will wait until one exits the critical code protected by the event
    if(autoReset.WaitOne(3000))
    {
         try
         {
             // Product selling stuff
         }
         finally
         {
             autoReset.Set();
         }
    }
    else
    {
        // Thread waited 3 seconds. Maybe you should do something in order to prevent users'
        // wait time when they want to sell something.
    }
