	public static class TaskBarLocationProvider
	{
		// P/Invoke goo:
		private const int ABM_GETTASKBARPOS = 5;
		[DllImport("shell32.dll")]
		private static extern IntPtr SHAppBarMessage(int msg, ref AppBarData data);
		/// <summary>
		/// Where is task bar located (at top of the screen, at bottom (default), or at the one of sides)
		/// </summary>
		private enum Dock
		{
			Left = 0,
			Top = 1,
			Right = 2,
			Bottom = 3
		}
		private struct Rect
		{
			public int Left, Top, Right, Bottom;
		}
		private struct AppBarData
		{
			public int cbSize;
			public IntPtr hWnd;
			public int uCallbackMessage;
			public Dock Dock;
			public Rect rc;
			public IntPtr lParam;
		}
		private static Rectangle GetTaskBarCoordinates(Rect rc)
		{
			return new Rectangle(rc.Left, rc.Top,
				rc.Right - rc.Left, rc.Bottom - rc.Top);
		}
		private static AppBarData GetTaskBarLocation()
		{
			var data = new AppBarData();
			data.cbSize = Marshal.SizeOf(data);
			IntPtr retval = SHAppBarMessage(ABM_GETTASKBARPOS, ref data);
			if (retval == IntPtr.Zero)
			{
				throw new Win32Exception("WinAPi Error: does'nt work api method SHAppBarMessage");
			}
			return data;
		}
		private static Screen FindScreenWithTaskBar(Rectangle taskBarCoordinates)
		{
			foreach (var screen in Screen.AllScreens)
			{
				if (screen.Bounds.Contains(taskBarCoordinates))
				{
					return screen;
				}
			}
			return Screen.PrimaryScreen;
		}
		/// <summary>
		/// Calculate wpf window position for place it near to taskbar area
		/// </summary>
		/// <param name="windowWidth">target window height</param>
		/// <param name="windowHeight">target window width</param>
		/// <param name="left">Result left coordinate <see cref="System.Windows.Window.Left"/></param>
		/// <param name="top">Result top coordinate <see cref="System.Windows.Window.Top"/></param>
		public static void CalculateWindowPositionByTaskbar(double windowWidth, double windowHeight, out double left, out double top)
		{
			var taskBarLocation = GetTaskBarLocation();
			var taskBarRectangle = GetTaskBarCoordinates(taskBarLocation.rc);
			var screen = FindScreenWithTaskBar(taskBarRectangle);
			left = taskBarLocation.Dock == Dock.Left
				? screen.Bounds.X + taskBarRectangle.Width
				: screen.Bounds.X + screen.WorkingArea.Width - windowWidth;
			top = taskBarLocation.Dock == Dock.Top
				? screen.Bounds.Y + taskBarRectangle.Height
				: screen.Bounds.Y + screen.WorkingArea.Height - windowHeight;
		}
