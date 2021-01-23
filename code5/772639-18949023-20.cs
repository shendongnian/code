    private void WatchThread(object pointer)
    {
        try
        {
            ((Delegate) pointer).DynamicInvoke();
        }
        catch (Exception e) { /* log error and stop service */ }
    }
