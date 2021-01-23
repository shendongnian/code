    using System.Threading;
    Timer delayedActionTimer;
    public MyClass()
    {
        // Setup our timer
        delayedActionTimer = new Timer(saveOrWhatever, // The method to call when triggered
                                       null, // State object (Not required)
                                       Timeout.Infinite, // Start disabled
                                       Timeout.Infinite); // Don't repeat the trigger
    }
    
    // A change was made that we want to save but not until a
    // reasonable amount of time between changes has gone by
    // so that we're not saving on every keystroke/trigger event.
    public void TextChanged()
    {
        delayedActionTimer.Change(3000, // Trigger this timers function in 3 seconds,
                                        // overwriting any existing countdown
                                  Timeout.Infinite); // Don't repeat this trigger; Only fire once
    }
    // Timer requires the method take an Object which we've set to null since we don't
    // need it for this example
    private void saveOrWhatever(Object obj) 
    {
        /*Do the thing*/
    }
