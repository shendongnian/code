    public void DispatchIfNecessary(Action action) {
        if (!Dispatcher.CheckAccess())
            Dispatcher.Invoke(action);
        else
            action.Invoke();
    }
