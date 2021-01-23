    /// <summary>
    /// Called when a connection disconnects from this hub gracefully or due to a timeout.
    /// </summary>
    /// <param name="stopCalled">
    /// true, if stop was called on the client closing the connection gracefully;
    /// false, if the connection has been lost for longer than the
    /// <see cref="Configuration.IConfigurationManager.DisconnectTimeout"/>.
    /// Timeouts can be caused by clients reconnecting to another SignalR server in scaleout.
    /// </param>
    /// <returns>A <see cref="Task"/></returns>
    public virtual Task OnDisconnected(bool stopCalled)
    {
        return TaskAsyncHelper.Empty;
    }
