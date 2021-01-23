        public BitmapImage ConvertWriteableBitmapToBitmapImage(WriteableBitmap wbm)
		{
			bmp = new BitmapImage();
			using (MemoryStream stream = new MemoryStream())
			{
				BmpBitmapEncoder encoder = new BmpBitmapEncoder();
				encoder.Frames.Add(BitmapFrame.Create(wbm));
				encoder.Save(stream);
				bmp.BeginInit();
				bmp.CacheOption = BitmapCacheOption.OnLoad;
				bmp.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
				bmp.StreamSource = new MemoryStream(stream.ToArray()); //stream;
				bmp.EndInit();
				bmp.Freeze();
			}
			return bmp;
		}
