    	public GdiBitmap(int width, int height)
    	{
    		using (Bitmap bitmap = new Bitmap(width, height))
    			Initialize(bitmap);
    	}
    private void Initialize(Bitmap bitmap)
    	{
    		_size = bitmap.Size;
    		_handle = new GdiHandle(bitmap.GetHbitmap(), true);
    		_deviceContext = UnsafeNativeMethods.CreateCompatibleDC(IntPtr.Zero);
    		UnsafeNativeMethods.SelectObject(_deviceContext, _handle);
    	}
