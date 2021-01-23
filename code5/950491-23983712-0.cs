    public delegate Task AsyncEventHandler(object sender, EventArgs e);
    public event AsyncEventHandler X;
    public async Task OnX(EventArgs e) {
      // ...
      var @event = X;
      if (@event != null)
        await Task.WhenAll(
          Array.ConvertAll(
            @event.GetInvocationList(),
            d => ((AsyncEventHandler)d)(this, e)));
    }
