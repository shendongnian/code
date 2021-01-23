	public static BitmapImage ImageFromUriSync(string uri)
	{
		using(var client = new WebClient())
		{
			byte[] data = client.DownloadData(uri);
			using(var stream = new MemoryStream(data))
			{
				var img = new BitmapImage();
				img.BeginInit();
				img.CacheOption = BitmapCacheOption.OnLoad;
				img.StreamSource = stream;
				img.EndInit();
				return img;
			}
		}
	}
