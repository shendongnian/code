    public void InvokeHoverClick(HandPosition hand)
    {
        // additional logic removed for answer sanity
        var t = new DispatcherTimer();
        t.Interval = TimeSpan.FromSeconds(0.6);
        t.Tick += (o, s) =>
                      {
                          t.Stop();
                          var clickArgs = new HandInputEventArgs(HoverClickEvent, this, hand);
                          this.RaiseEvent(clickArgs);
                          this.IsSelected = false;
                      };
        t.Start();
    }
