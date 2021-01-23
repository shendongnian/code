    public static event EventHandler MyEvent;
    public static void RaiseMyEvent()
    {
        if (MyEvent != null) MyEvent(null, EventArgs.Empty);
    }
