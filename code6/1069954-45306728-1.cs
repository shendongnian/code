    internal static class EventExtensions
    {
    	public static void InvokeAsync<TEventArgs>(this EventHandler<TEventArgs> @event, object sender,
    		TEventArgs args, AsyncCallback ar, object userObject = null)
    		where TEventArgs : class
    	{
    		var listeners = @event.GetInvocationList();
    		foreach (var t in listeners)
    		{
    			var handler = (EventHandler<TEventArgs>) t;
    			handler.BeginInvoke(sender, args, ar, userObject);
    		}
    	}
    }
