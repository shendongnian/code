	protected override void OnSourceInitialized(EventArgs e)
	{
		base.OnSourceInitialized(e);
		HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
		source.AddHook(WndProc);
	}
	private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
	{
		if (msg == 0x1c)
		{
			OnActivateApp(wParam != IntPtr.Zero);
		}
		return IntPtr.Zero;
	}
	protected void OnActivateApp(bool activate)
	{
		Console.WriteLine("Activate {0}", activate);
	}
