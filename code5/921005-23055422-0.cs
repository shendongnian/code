    public int Height {
		get {
			uint height;			
			Status status = GDIPlus.GdipGetImageHeight (nativeObject, out height);		
			GDIPlus.CheckStatus (status);			
			return (int)height;
		}
	}
    public int Width {
		get {
			uint width;			
			Status status = GDIPlus.GdipGetImageWidth (nativeObject, out width);		
			GDIPlus.CheckStatus (status);			
			return (int)width;
		}
	}
