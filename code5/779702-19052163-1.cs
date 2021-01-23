    public class EventInhibitor : IDisposable
    {
      private bool _disposed = false;
      private EventInfo _event;
      private EventHandler _handler;
      private Control _control;
    
      public EventInhibitor(Control c, string EventName, EventHandler handler)
      {
        _event = c.GetType().GetEvent(EventName); 
        _handler = handler;
        _control = c;
        _event.RemoveEventHandler(_control, _handler);
      }
    
      public void Dispose()
      {
          if (_disposed)
              return;
    
          _event.AddEventHandler(_control, _handler);
        _event = null;
        _handler = null;
        _control = null;
        _disposed = true;
      }
    }
