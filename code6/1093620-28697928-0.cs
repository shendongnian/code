    #region Usings
    using System;
    using System.Collections;
    
    
    #endregion
    
    
    namespace EProm.Common.PInvoke
    {
    	/// <summary>
    	/// Catch process child windows, setting them in foreground.
    	/// <see cref="http://stackoverflow.com/questions/28559726/set-to-foreground-a-third-party-dialog-in-a-windows-form-application"/>
    	/// </summary>
    	public class DialogsCatcher
    	{
    		#region Fields
    		private readonly ILog _log;
    		private readonly int _processId;
    		private readonly Timer _timer;
    		private readonly IntPtr _windowHandle;
    		#endregion
    
    
    		#region Constructors
    		public DialogsCatcher(int processId, int interval, IntPtr windowHandle)
    		{
    			_log = LogManager.GetLogger(GetType().Name);
    
    			_processId = processId;
    			_windowHandle = windowHandle;
    
    			_timer = new Timer();
    			_timer.Elapsed += new ElapsedEventHandler(CatchDialogs);
    			_timer.Enabled = true;
    			_timer.Interval = interval;
    
    			_log.Debug("DialogsCatcher initialized.");
    		}
    		#endregion
    
    
    		#region Public Methods
    		public void StartMonitoring()
    		{
    			_timer.Start();
    
    			_log.Debug("DialogsCatcher started.");
    		}
    
    		public void StopMonitoring()
    		{
    			_timer.Stop();
    
    			_log.Debug("DialogsCatcher stopped.");
    		}
    		#endregion
    
    
    		#region Private Methods
    		private void CatchDialogs(object sender, EventArgs e)
    		{
    			GetProcessOpenedWindowsByProcessId(_processId, _windowHandle);
    		}
    
    		//nando20150219: meaningful names, you're doin' it right! :)
    		private void GetProcessOpenedWindowsByProcessId(int processId, IntPtr windowHandle)
    		{
    			var shellWindowHandle = User32.GetShellWindow();
    			var windows = new Dictionary<IntPtr, string>();
    
    			EnumWindowsProc filter = (windowHandle, lp) =>
    			{
    				int length = User32.GetWindowTextLength(windowHandle);
    				
    				var windowText = new StringBuilder(length);
    				User32.GetWindowText(windowHandle, windowText, length + 1);
    				windows.Add(windowHandle, windowText.ToString());
    
    				var isWindowVisible = User32.IsWindowVisible(windowHandle);
    
    				if (windowHandle == shellWindowHandle)
    				{
   					return true;
    				}
    
    				if (!isWindowVisible)
    				{
    					return true;
    				}
    
    				if (length == 0)
    				{
    					return true;
    				}
    
    				uint windowPid;
    				User32.GetWindowThreadProcessId(windowHandle, out windowPid);
    				if (windowPid != processId)
    				{
    					return true;
    				}
    
    				if (windowHandle != windowHandle)
    				{
    					//nando20150218: set window to foreground
    					User32.SetForegroundWindow(windowHandle);
    					_log.DebugFormat("Window \"{0}\" moved to foreground.", windowText);
    				}
    
    				return true;
    			};
    			User32.EnumWindows(filter, 0);
    
    #if DEBUG
    			//foreach (var dictWindow in windows)
    			//{
    			//	_log.DebugFormat("WindowHandle: {0} - WindowTitle: {1}", dictWindow.Key, dictWindow.Value);
    			//}
    #endif 
    		}
    		#endregion
    	}
    
    	
    	#region Delegates
    	public delegate bool EnumWindowsProc(IntPtr windowHandle, IntPtr lp);
    
    	public delegate bool EnumedWindow(IntPtr windowHandle, ArrayList windsowHandles);
    	#endregion
    	
    
    	/// <summary>
    	/// Windows User32.dll wrapper
    	/// </summary>
    	/// <see cref="http://pinvoke.net/"/>
    	public class User32
    	{
    		#region Public Methods
    		[DllImport("user32.dll")]
    		[return: MarshalAs(UnmanagedType.Bool)]
    		public static extern bool IsWindowVisible(IntPtr hWnd);
    
    		[DllImport("user32.dll", EntryPoint = "GetWindowText", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
    		public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);
    
    		[DllImport("user32.dll", SetLastError = true)]
    		public static extern uint GetWindowThreadProcessId(IntPtr hwnd, out uint lpdwProcessId);
    
    		[DllImport("user32.dll")]
    		[return: MarshalAs(UnmanagedType.Bool)]
    		public static extern bool SetForegroundWindow(IntPtr hWnd);
    
    		[DllImport("user32.DLL")]
    		public static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);
    
    		[DllImport("user32.DLL")]
    		public static extern int GetWindowTextLength(IntPtr hWnd);
    
    		[DllImport("user32.DLL")]
    		public static extern IntPtr GetShellWindow();
    		#endregion
    	}
    }
