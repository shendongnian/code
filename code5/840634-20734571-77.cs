    // List to hold the event handlers:
    List<EventHandler> myEventHandlers = new List<EventHandler>();
    // Event declaration:
    event EventHandler MyEvent
    {
        add
        {
            lock (myEventHandlers)
            {
                myEventHandlers.Add(value);
            }
        }
        remove
        {
            lock (myEventHandlers)
            {
                myEventHandlers.Remove(value);
            }
        }
    }
    // Method to raise the event (aka event dispatcher):
    private void Raise_MyEvent()
    {
        var e = new EventArgs();
        foreach (var item in myEventHandlers)
        {
            item(this, e);
        }
    }
