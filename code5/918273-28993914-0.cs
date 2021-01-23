    public class MouseWheelActivityMonitor
    {        
    	private readonly UIElement _canvas;
    	private readonly AutoResetEvent _resetMonitorEvent;
    	private readonly Dispatcher _dispatcher;
    	private readonly int _sensitivity;
    
    	private volatile bool _inactive;
    	private volatile bool _stopped;        
    
    	public event EventHandler<MouseWheelEventArgs> MouseWheel;
    	public event EventHandler<EventArgs> MouseWheelStarted;        
    	public event EventHandler<EventArgs> MouseWheelStopped;
    
    	public MouseWheelActivityMonitor(UIElement canvas, int sensitivity)
    	{
    		_canvas = canvas;
    		_canvas.MouseWheel += (s, e) => RaiseMouseWheel(e);
    
    		_sensitivity = sensitivity;
    		_dispatcher = Dispatcher.CurrentDispatcher;
    		_resetMonitorEvent = new AutoResetEvent(false);
    
    		_inactive = true;
    		_stopped = true;
    
    		var monitor = new Thread(Monitor) {IsBackground = true};
    		monitor.Start();
    	}
    
    	private void Monitor()
    	{
    		while (true)
    		{
    			if (_inactive) // if wheel is not active...
    			{
    				_resetMonitorEvent.WaitOne(_sensitivity/10);
    				continue; // ...do nothing
    			}
    			// if wheel is running...
    			_inactive = true; // ...purposly change the state to inactive
    			_resetMonitorEvent.WaitOne(_sensitivity); // wait...
    			if (_inactive) // ...and after specified time check if the state is still not re-activated by wheel event
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
    }
