		public static void bringWindowToFront(System.Windows.Forms.Form form)
		{
			uint foreThread = GetWindowThreadProcessId(GetForegroundWindow(), System.IntPtr.Zero);
			uint appThread = GetCurrentThreadId();
			const uint SW_SHOW = 5;
			if (foreThread != appThread)
			{
				AttachThreadInput(foreThread, appThread, true);
				BringWindowToTop(form.Handle);
				ShowWindow(form.Handle, SW_SHOW);
				AttachThreadInput(foreThread, appThread, false);
			}
			else
			{
				BringWindowToTop(form.Handle);
				ShowWindow(form.Handle, SW_SHOW);
			}
			form.Activate();
		}
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
		[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
		private static extern bool BringWindowToTop(System.IntPtr hWnd);
		[System.Runtime.InteropServices.DllImport("kernel32.dll")]
		public static extern uint GetCurrentThreadId();
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern System.IntPtr GetForegroundWindow();
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern uint GetWindowThreadProcessId(System.IntPtr hWnd, System.IntPtr ProcessId);
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern bool ShowWindow(System.IntPtr hWnd, uint nCmdShow);
