	public static async Task CropImage()
	{
		var client = new WebClient();
		var sourceimg = new Uri(@"http://logonoid.com/images/stack-overflow-logo.png");
		var destination = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "logoCropped.png"));
		if (destination.Exists)
			destination.Delete();
		using (Stream sourceStream = await client.OpenReadTaskAsync(sourceimg))
		{
			using (Bitmap source = new Bitmap(sourceStream))
			{
				Rectangle cropzone = new Rectangle(0, 0, 256, 256);
				using (Bitmap croppedBitmap = source.Clone(cropzone, source.PixelFormat))
				{
					croppedBitmap.Save(destination.FullName, ImageFormat.Png);
				}
			}
		}
	}
