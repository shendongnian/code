    public void AddFontFile(string filename)
    {
    	IntSecurity.DemandReadFileIO(filename);
	    int num = SafeNativeMethods.Gdip.GdipPrivateAddFontFile(new HandleRef(this, this.nativeFontCollection), filename);
    	if (num != 0)
	    {
		    throw SafeNativeMethods.Gdip.StatusException(num);
    	}
	    SafeNativeMethods.AddFontFile(filename);
    }
