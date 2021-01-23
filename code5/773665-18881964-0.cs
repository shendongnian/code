    /// <summary>
    /// Extension method to safely encapsulate asynchronous event calls with checks
    /// </summary>
    /// <param name="evnt">The event to call</param>
    /// <param name="sender">The sender of the event</param>
    /// <param name="args">The arguments for the event</param>
    /// <param name="object">The state information that is passed to the callback method</param>
    /// <remarks>
    /// This method safely calls the each event handler attached to the event. This method uses <see cref="System.Threading.Tasks"/> to
    /// asynchronously call invoke without any exception handling. As such, if any of the event handlers throw exceptions the application will
    /// most likely crash when the task is collected. This is an explicit decision since it is really in the hands of the event handler
    /// creators to make sure they handle issues that occur do to their code. There isn't really a way for the event raiser to know
    /// what is going on.
    /// </remarks>
    [System.Diagnostics.DebuggerStepThrough]
    public static void AsyncSafeInvoke( this EventHandler evnt, object sender, EventArgs args )
    {
        // Used to make a temporary copy of the event to avoid possibility of
        // a race condition if the last subscriber unsubscribes
        // immediately after the null check and before the event is raised.
        EventHandler handler = evnt;
        if (handler != null)
        {
            // Manually calling all event handlers so that we can capture and aggregate all the
            // exceptions that are thrown by any of the event handlers attached to this event.  
            var invocationList = handler.GetInvocationList();
            foreach (EventHandler h in invocationList)
            {
                // Explicitly not catching any exceptions. While there are several possibilities for handling these 
                // exceptions, such as a callback, the correct place to handle the exception is in the event handler.
                Task.Factory.StartNew(() =>
                {
                    h.Invoke(sender, args);
                });
            }
        }
    }
