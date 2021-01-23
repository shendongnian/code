      // ViewModel - define event
      public event EventHandler Loaded;
      // View - subscription
      IDisposable _subscription;
      // View - in ViewDidLoad
      _subscription = typeof(HomeViewModel)
                          .GetEvent("Loaded")
                          .WeakSubscribe(this.ViewModel, OnLoaded);
      // View - event handler
      public void OnLoaded(object sender, EventArgs e)
      {
         LoadControls();
      }
