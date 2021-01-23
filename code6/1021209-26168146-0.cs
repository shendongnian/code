    /// <summary>
    ///     Locks a Bitmap into system memory.
    /// </summary>
    public unsafe void LockBits()
    {
	    var width = this.Bitmap.Width;
	    var height = this.Bitmap.Height;
	    var imageLockMode = ImageLockMode.UserInputBuffer;
	    // Setting imageLockMode
	    imageLockMode = imageLockMode | ImageLockMode.ReadOnly;
	    imageLockMode = imageLockMode | ImageLockMode.WriteOnly;
	    // Save the bouunds
	    this._bounds = new Rectangle(0, 0, width, height);
	    // Create Pointer
	    var someBuffer = new uint[width*height];
	    // Pin someBuffer
	    fixed (uint* buffer = someBuffer) //pin
	    {
		    // Create new bitmap data.
		    var temporaryData = new BitmapData
		    {
			    Width = width,
			    Height = height,
			    PixelFormat = PixelFormat.Format32bppArgb,
			    Stride = width*4,
			    Scan0 = (IntPtr) buffer
		    };
		    // Get the data
		    this.BitmapData = this.Bitmap.LockBits(this._bounds, imageLockMode,     PixelFormat.Format32bppArgb,
			temporaryData);
		    // Set values
		    this.Buffer = someBuffer;
	   }
    }
