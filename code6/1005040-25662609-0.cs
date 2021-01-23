    BitmapImage BitmapToImageSource(System.Drawing.Bitmap bitmap, System.Drawing.Imaging.ImageFormat imgFormat)
    		{
    			using (MemoryStream memory = new MemoryStream())
    			{
    				bitmap.Save(memory, imgFormat);
    				memory.Position = 0;
    				BitmapImage bitmapImage = new BitmapImage();
    				bitmapImage.BeginInit();
    				bitmapImage.StreamSource = memory;
    				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
    				bitmapImage.EndInit();
    
    				return bitmapImage;
    			}
    		}
