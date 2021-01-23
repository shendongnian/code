    public sealed class MouseWheelMonitor : IDisposable
    {
    	private AutoResetEvent _resetMonitorEvent;
    	private readonly Dispatcher _dispatcher;
    	private readonly UIElement _canvas;
    	private readonly int _sensitivity;
    
        private bool _disposed;
    	private volatile bool _inactive;
    	private volatile bool _stopped;
    
    	public event EventHandler<MouseWheelEventArgs> MouseWheel;
    	public event EventHandler<EventArgs> MouseWheelStarted;        
    	public event EventHandler<EventArgs> MouseWheelStopped;
    
    	public MouseWheelMonitor(UIElement canvas, int sensitivity)
    	{
    		_canvas = canvas;
    		_canvas.MouseWheel += (s, e) => RaiseMouseWheel(e);
    
    		_sensitivity = sensitivity;
    		_dispatcher = Dispatcher.CurrentDispatcher;
    		_resetMonitorEvent = new AutoResetEvent(false);
    
            _disposed = false;
    		_inactive = true;
    		_stopped = true;
    
    		var monitor = new Thread(Monitor) {IsBackground = true};
    		monitor.Start();
    	}
    
    	private void Monitor()
    	{
    		while (!_disposed)
    		{
    			if (_inactive) // if wheel is still inactive...
    			{
    				_resetMonitorEvent.WaitOne(_sensitivity/10); // ...wait negligibly small quantity of time...
    				continue; // ...and check again
    			}
    			// otherwise, if wheel is active...
    			_inactive = true; // ...purposely change the state to inactive
    			_resetMonitorEvent.WaitOne(_sensitivity); // wait...
    			if (_inactive) // ...and after specified time check if the state is still not re-activated inside mouse wheel event
    				RaiseMouseWheelStopped();
    		}
    	}
    
    	private void RaiseMouseWheel(MouseWheelEventArgs args)
    	{
    		if (_stopped)
    			RaiseMouseWheelStarted();
    
    		_inactive = false;
    		if (MouseWheel != null)
    			MouseWheel(_canvas, args);
    	}
    
    	private void RaiseMouseWheelStarted()
    	{
    		_stopped = false;
    		if (MouseWheelStarted != null)
    			MouseWheelStarted(_canvas, new EventArgs());
    	}
    
    	private void RaiseMouseWheelStopped()
    	{
    		_stopped = true;
    		if (MouseWheelStopped != null)
    			_dispatcher.Invoke(() => MouseWheelStopped(_canvas, new EventArgs())); // invoked on cached dispatcher for convenience (because fired from non-UI thread)
    	}    
        public void Dispose()
        {
            if(!_disposed)
            {
                _disposed = true;
                DetachEventHandlers();
                if (_resetMonitorEvent != null)
                {
                    _resetMonitorEvent.Close();
                    _resetMonitorEvent = null;
                }
            }
        }
        private void DetachEventHandlers()
        {
            if (MouseWheel != null)
            {
                foreach (var handler in MouseWheel.GetInvocationList().Cast<EventHandler<MouseWheelEventArgs>>())
                {
                    MouseWheel -= handler;
                }
            }
            if (MouseWheelStarted != null)
            {
                foreach (var handler in MouseWheelStarted.GetInvocationList().Cast<EventHandler<EventArgs>>())
                {
                    MouseWheelStarted -= handler;
                }
            }
            if (MouseWheelStopped != null)
            {
                foreach (var handler in MouseWheelStopped.GetInvocationList().Cast<EventHandler<EventArgs>>())
                {
                    MouseWheelStopped -= handler;
                }
            }
        }
    }
