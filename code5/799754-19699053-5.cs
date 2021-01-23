    public partial class DraggedWindow : Window
	{
		private readonly MainWindow _mainWindow;
		private bool _isDropped = false;
		public DraggedWindow(MainWindow mainWindow)
		{
			_mainWindow = mainWindow;
			InitializeComponent();
			DataContext = new TabItem() { Header = "TabItem6", Content = "Content6" };
		}
		const uint GW_HWNDNEXT = 2;
		[DllImport("User32")]
		static extern IntPtr GetTopWindow(IntPtr hWnd);
		[DllImport("User32")]
		static extern IntPtr GetWindow(IntPtr hWnd, uint wCmd);
		[DllImport("User32")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetCursorPos(ref Win32Point pt);
		[StructLayout(LayoutKind.Sequential)]
		internal struct Win32Point
		{
			public Int32 X;
			public Int32 Y;
		};
		public static Point GetMousePosition()
		{
			Win32Point w32Mouse = new Win32Point();
			GetCursorPos(ref w32Mouse);
			return new Point(w32Mouse.X, w32Mouse.Y);
		}
		public Window FindWindowUnderThisAt(Point screenPoint)  // WPF units (96dpi), not device units
		{
			return (
			  from win in SortWindowsTopToBottom(Application.Current.Windows.OfType<Window>())
			  where new Rect(win.Left, win.Top, win.Width, win.Height).Contains(screenPoint)
			  && !Equals(win, this)
			  select win
			).FirstOrDefault();
		}
		public IEnumerable<Window> SortWindowsTopToBottom(IEnumerable<Window> unsorted)
		{
			var byHandle = unsorted.ToDictionary(win =>
				((HwndSource)PresentationSource.FromVisual(win)).Handle);
			for (IntPtr hWnd = GetTopWindow(IntPtr.Zero); hWnd != IntPtr.Zero; hWnd = GetWindow(hWnd, GW_HWNDNEXT))
			{
				if (byHandle.ContainsKey(hWnd))
					yield return byHandle[hWnd];
			}
		}
		private void DraggedWindow_OnMouseMove(object sender, MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				this.DragMove();
			}
			var absoluteScreenPos = GetMousePosition();
			var windowUnder = FindWindowUnderThisAt(absoluteScreenPos);
			if (windowUnder != null && windowUnder.Equals(_mainWindow))
			{
				if (_isDropped)
				{
					// Your code here
					var tabitem = new TabItem();
					tabitem.Content = (DataContext as TabItem).Content;
					tabitem.Header = (DataContext as TabItem).Header;
					_mainWindow.TabControl1.Items.Add(tabitem);
					this.Close();
				}
			}
		}
		private void DraggedWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			_isDropped = false;
		}
		private void DraggedWindow_OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			_isDropped = true;
		}
	}
