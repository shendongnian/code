    // this is going to keep trying to lock until it succeeds, after which it 
    //     will do whatever work needs done.
    while (true) {
      bool lockObtained = false;
      lock (objectInstance) {
        if (!objectInstance.IsBusy) {
          lockObtained = true;
          objectInstance.IsBusy = true;
        }
      }
      if (lockObtained) {
        // good to go here
        
        // and don't forget to clear the IsBusy
        objectInstance.IsBusy = false;
        break;
      }
    }
