    // This will be the signature of your event handlers
    public delegate void ChangedEventHandler(object sender, ProductChangedEventArgs e);
    // The event itself to which will be possible to bind callbacks functions
    //   with the signature given by ChangedEventHandler
    public event ChangedEventHandler Changed;
    protected virtual void OnChanged(ChangedEventArgs e) 
    {
      // This checks there's at least one callback bound to the event
      if (Changed != null){
        // If there are callbacks, call all of them
        Changed(this, e);
      }
    }
    
