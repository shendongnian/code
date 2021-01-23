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
    } else {
        // busy loop waiting for the flag to clear could go here
    }
