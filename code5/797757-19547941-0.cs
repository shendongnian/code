    private void RemoveHandlers(DispatcherTimer dispatchTimer)
    {
        var eventField = dispatchTimer.GetType().GetField("Tick",
                BindingFlags.NonPublic | BindingFlags.Instance);
        var eventDelegate = (Delegate) eventField.GetValue(dispatchTimer);
        var invocatationList = eventDelegate.GetInvocationList();
     
        foreach (var handler in invocatationList)
            dispatchTimer.Tick -= ((EventHandler) handler);
    }
