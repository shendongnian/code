    /// <summary>Gets the height, in pixels, of this <see cref="T:System.Drawing.Image" />.</summary>
    /// <returns>The height, in pixels, of this <see cref="T:System.Drawing.Image" />.</returns>
    public int Height
    {
    	[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    	get
    	{
    		int result;
    		int num = SafeNativeMethods.Gdip.GdipGetImageHeight(new HandleRef(this, this.nativeImage), out result);
    		if (num != 0)
    		{
    			throw SafeNativeMethods.Gdip.StatusException(num);
    		}
    		return result;
    	}
    }
