    private static Image CropAndCompressImage(Image image, Rectangle rectangle, ImageFormat imageFormat)
    {
    	using(Bitmap bitmap = new Bitmap(image))
    	{
    		using(Bitmap cropped = bitmap.Clone(rectangle, bitmap.PixelFormat))
    		{
    			using (MemoryStream memoryStream = new MemoryStream())
    			{
    				cropped.Save(memoryStream, imageFormat);
    				return new Bitmap(Image.FromStream(memoryStream));
    			}
    		}
    	}
    }
