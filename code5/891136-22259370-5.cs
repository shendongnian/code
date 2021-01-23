	public class BrowserPanel : Panel
    {				
		public BrowserForm Browser { get; private set; }
		
		private IntPtr _threadownerhandle;
		private IntPtr _threadformhandle;
		private Thread _thread;
		private AutoResetEvent _threadlock;
		
		public BrowserPanel(): Panel
		{
			Resize += OnResize;
			ThreadCreate();            
		}	
		public void ThreadCreate()
		{
			// The following line creates a window handle to the BrowserPanel
			// This has to be done in the UI thread, but the handle can be used in an other thread
			_threadownerhandle = Handle;
			
			// A waiting lock
			_threadlock = new AutoResetEvent(false);
			
			// Create the thread for the BrowserForm
			_thread = new Thread(ThreadStart);
			_thread.SetApartmentState(ApartmentState.STA);
			_thread.Start();
			
			// Let's wait until the Browser object has been created
			_threadlock.WaitOne();
		}
		
		private void ThreadStart()
		{	
			// This a NOT the UI thread
			try
			{
				// Create the BrowserForm in a new thread
				Browser = new BrowserForm(this);
				
				// Get the handle of the form. This has to be done in the creator thread
				_threadformhandle = Browser.Handle;
				
				// The magic. The BrowserForm is added to the BrowserPanel
				User32.SetParent(_threadformhandle, _threadownerhandle);
				
				// Make the BrowserForm the same size as the BrowserPanel
				ThreadWindowUpdate();
			}
			finally
			{
				// Notify the BrowserPanel we are finished with the creation of the Browser
				_threadlock.Set();
			}
			try
			{
				// With the next line a (blocking) message loop is started
				Application.Run(Browser); 
			}
			finally
			{
				Browser.Dispose();
			}
		}
		
        private void OnResize(object sender, EventArgs e)
        {
			// Resizing the BrowserPanel will resize the BrowserForm too
            if (Browser != null) ThreadWindowUpdate();
        }				
		public void ThreadWindowUpdate()
		{
			if (Browser == null) return;
			User32.SetWindowPos(_threadformhandle, IntPtr.Zero, 0, 0, Width, Height, 0);
		}
	}
	
