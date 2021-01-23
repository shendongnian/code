    	private static Bitmap GenBitmap(int width, int height) {
			int ch = 3; //number of channels (ie. assuming 24 bit RGB in this case)
			Random rnd = new Random();
			int imageByteSize = width * height * ch;
			byte[] imageData = new byte[imageByteSize]; //your image data buffer
			rnd.NextBytes(imageData); 		//Fill with random bytes;
			Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
			BitmapData bmData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
			IntPtr pNative = bmData.Scan0;
			Marshal.Copy(imageData, 0, pNative, imageByteSize);
			bitmap.UnlockBits(bmData);
			return bitmap;
		
		}
