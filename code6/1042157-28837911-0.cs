    class MyWindow : Window
	{
		private const int WM_MOVING = 0x0216;
		private HwndSource _hwndSrc;
		private HwndSourceHook _hwndSrcHook;
		public MyWindow()
		{
			Loaded += OnLoaded;
			Unloaded += OnUnloaded;
		}
		void OnUnloaded(object sender, RoutedEventArgs e)
		{
			_hwndSrc.RemoveHook(_hwndSrcHook);
			_hwndSrc.Dispose();
			_hwndSrc = null;
		}
		void OnLoaded(object sender, RoutedEventArgs e)
		{
			_hwndSrc = HwndSource.FromDependencyObject(this) as HwndSource;
			_hwndSrcHook = FilterMessage;
			_hwndSrc.AddHook(_hwndSrcHook);
		}
		private IntPtr FilterMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			switch (msg)
			{
				case WM_MOVING:
					OnLocationChange();
					break;
			}
			return IntPtr.Zero;
		}
		private void OnLocationChange()
		{
			//Do something
		}
	}
