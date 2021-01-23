    private void initialize()
	{
		IntPtr surface = DLL.Initialize(new WindowInteropHelper(this).Handle,
				(int)button.ActualWidth, (int)button.ActualHeight);
		if (surface != IntPtr.Zero)
		{
			d3dImage.Lock();
			d3dImage.SetBackBuffer(D3DResourceType.IDirect3DSurface9, surface);
			d3dImage.Unlock();
			CompositionTarget.Rendering += CompositionTarget_Rendering;
		}
	}
