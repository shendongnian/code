    bool createdMutex;
    using (var processMutex = new System.Threading.Mutex(false, "Some name that is unique for the executable", out createdMutex)) {
       if (!createdMutex)
         ; // some other instance of the application is already running (or starting up). You may want to bring the other instance to foreground (assuming this is a GUI app)
       else 
       {
          // this is the process to actually run..
          // do application init stuff here
       }
    }
    
