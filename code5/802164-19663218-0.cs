    private EventHandler _myEvent;
    public event EventHandler MyEvent
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        add 
        { 
            if (CanAddEventHandler()) // <- that's yours to implement
            {
                 _myEvent = (EventHandler)Delegate.Combine(_myEvent, value);
            }
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        remove 
        { 
            _myEvent = (EventHandler)Delegate.Remove(_myEvent, value); 
        }
    }
