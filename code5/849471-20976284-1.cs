    if ((DateTime.Now - lastCheck).TotalMinutes >= MINUTES_CHECK)
    {
        if (checkThread == null ||
           (checkThread.ThreadState != System.Threading.ThreadState.Running &&  
            checkThread.ThreadState != System.Threading.ThreadState.WaitSleepJoin)
         )
        {
            lock( _syncRoot ) {
               checkThread = new Thread(DoCheck);
               checkThread.Start();
               Console.WriteLine("Checking for items...");
               lastCheck = DateTime.Now;
            }
        }
    }
