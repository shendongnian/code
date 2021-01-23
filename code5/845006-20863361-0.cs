    public void ScrollBarChange(EventArgs e) {
       // to call the routine:
       Thread myThread = new Thread(new ThreadStart(DatabaseIO));
       myThread.Start();
       // any other code you need to run immediately
    }
    public void DatabaseIO() {
       try {
         Monitor.Enter(this);
         if (ioActive) { pendingEvents = true; return; }
         ioActive = true;
       } finally {
         Monitor.Exit(this);
       }
       // run the database io normally here...
       // check pending events and call "DatabaseIO" again to make sure everything is processed
       if (pendingEvents) {
         pendingEvents = false;
         DatabaseIO();
       }
    }
