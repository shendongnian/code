    private int _eventSubscriptionCount = 0;
    public event EventHandler<EventArgs> RenderingEventWrapper
    {
        add
        {
            CompositionTarget.RenderingEvent += value;
            _eventSubscriptionCount++;
        }
        remove
        {
            CompositionTarget.RenderingEvent -= value;
            _eventSubscriptionCount--;
        }
    } 
