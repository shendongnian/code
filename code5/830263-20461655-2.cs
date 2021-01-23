    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace Extensions
    {
    	public static class WaitExt
    	{
    		/// <summary>
    		/// Wait for a handle and pump messages with DoEvents
    		/// by noseratio - http://stackoverflow.com/a/20461655/1768303
    		/// </summary>
    		public static bool WaitWithDoEvents(this WaitHandle handle, CancellationToken token, int timeout)
    		{
    			if (SynchronizationContext.Current as System.Windows.Forms.WindowsFormsSynchronizationContext == null)
    			{
    				// http://stackoverflow.com/a/19555959
    				throw new ApplicationException("Internal error: WaitWithDoEvents must be called on a thread with WindowsFormsSynchronizationContext.");
    			}
    
    			const uint EVENT_MASK = Win32.QS_ALLINPUT;
    			IntPtr[] handles = { handle.SafeWaitHandle.DangerousGetHandle() };
    
    			// track timeout if not infinite
    			Func<bool> hasTimedOut = () => false;
    			int remainingTimeout = timeout;
    
    			if (timeout != Timeout.Infinite)
    			{
    				// can't use Environment.TickCount, it is integer and may have a problem with timer wrapping
    				uint startTick = Win32.GetTickCount();
    				hasTimedOut = () =>
    				{
    					var lapse = unchecked((int)(Win32.GetTickCount() - startTick));
    					remainingTimeout = Math.Max(timeout - lapse, 0);
    					return remainingTimeout == 0;
    				};
    			}
    
    			while (true)
    			{
    				token.ThrowIfCancellationRequested(); // throw if cancellation requested from outside
    
    				if (handle.WaitOne(0)) // instant check
    					return true;
    
    				System.Windows.Forms.Application.DoEvents();
    
    				if (hasTimedOut())
    					return false; // timed out
    
    				if ((Win32.GetQueueStatus(EVENT_MASK) >> 16) != 0) // high word is non-zero if an input/message is still in the queue
    					continue;
    
    				// raise Idle event
    				System.Windows.Forms.Application.RaiseIdle(EventArgs.Empty);
    
    				if (hasTimedOut())
    					return false;
    
    				// wait for either a Windows message or the handle
    				// MsgWaitForMultipleObjectsEx with MWMO_INPUTAVAILABLE returns even if there's a message in the message queue already seen but not removed
    				var result = Win32.MsgWaitForMultipleObjectsEx(1, handles, (uint)remainingTimeout, EVENT_MASK, Win32.MWMO_INPUTAVAILABLE);
    				if (result == Win32.WAIT_OBJECT_0 || result == Win32.WAIT_ABANDONED_0)
    					return true; // handle signalled 
    				if (result == Win32.WAIT_TIMEOUT)
    					return false; // timed out
    				if (result == Win32.WAIT_OBJECT_0 + 1) // an input/message pending
    					continue;
    				// unexpected result
    				throw new InvalidOperationException();
    			}
    		}
    
    		public static bool WaitWithDoEvents(this WaitHandle handle, int timeout)
    		{
    			return WaitWithDoEvents(handle, CancellationToken.None, timeout);
    		}
    
    		public static bool WaitWithDoEvents(this WaitHandle handle)
    		{
    			return WaitWithDoEvents(handle, CancellationToken.None, Timeout.Infinite);
    		}
    
    		/// <summary>
    		/// Win32 interop declarations
    		/// </summary>
    		public static class Win32
    		{
    			public const uint QS_KEY = 0x0001;
    			public const uint QS_MOUSEMOVE = 0x0002;
    			public const uint QS_MOUSEBUTTON = 0x0004;
    			public const uint QS_POSTMESSAGE = 0x0008;
    			public const uint QS_TIMER = 0x0010;
    			public const uint QS_PAINT = 0x0020;
    			public const uint QS_SENDMESSAGE = 0x0040;
    			public const uint QS_HOTKEY = 0x0080;
    			public const uint QS_ALLPOSTMESSAGE = 0x0100;
    			public const uint QS_RAWINPUT = 0x0400;
    
    			public const uint QS_MOUSE = (QS_MOUSEMOVE | QS_MOUSEBUTTON);
    			public const uint QS_INPUT = (QS_MOUSE | QS_KEY | QS_RAWINPUT);
    			public const uint QS_ALLEVENTS = (QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY);
    			public const uint QS_ALLINPUT = (QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY | QS_SENDMESSAGE);
    
    			public const uint MWMO_INPUTAVAILABLE = 0x0004;
    
    			public const uint WAIT_TIMEOUT = 0x00000102;
    			public const uint WAIT_FAILED = 0xFFFFFFFF;
    			public const uint INFINITE = 0xFFFFFFFF;
    			public const uint WAIT_OBJECT_0 = 0;
    			public const uint WAIT_ABANDONED_0 = 0x00000080;
    
    			[DllImport("kernel32.dll")]
    			public static extern uint GetTickCount();
    
    			[DllImport("user32.dll")]
    			public static extern uint GetQueueStatus(uint flags);
    
    			[DllImport("user32.dll", SetLastError = true)]
    			public static extern uint MsgWaitForMultipleObjectsEx(
    				uint nCount, IntPtr[] pHandles, uint dwMilliseconds, uint dwWakeMask, uint dwFlags);
    		}
    	}
    }
