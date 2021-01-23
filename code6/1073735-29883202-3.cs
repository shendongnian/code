    private void CompositionTarget_Rendering(object sender, EventArgs e)
	{
		if (d3dImage.IsFrontBufferAvailable)
		{
			d3dImage.Lock();
			DLL.Render();
			// Invalidate the whole area:
			d3dImage.AddDirtyRect(new Int32Rect(0, 0, d3dImage.PixelWidth, d3dImage.PixelHeight));
			d3dImage.Unlock();
		}
	}
