    private void RaiseEvent(EventHandler<TEventArgs> handler,
                            TEventArgs parameter)
    {
      if(handler != null)
      {
        handler(this, parameter);
      }
    }
    
    private void RaiseEvent(EventHandler handler)
    {
      if(handler != null)
      {
        handler(this, EventArgs.Empty);
      }
    }
