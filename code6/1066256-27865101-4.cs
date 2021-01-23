	public sealed class MovieViewModel
	{
		public MovieViewModel(Movie movie, ThumbnailCache thumbnailCache)
		{
			_thumbnailId = movie.ThumbnailId;
			_thumbnailCache = thumbnailCache;
			Id = movie.Id;
			Name = movie.Name;
			// copy other property values across
		}
		readonly int _thumbnailId;
		readonly ThumbnailCache _thumbnailCache;
		public int Id { get; private set; }
		public string Name { get; private set; }
		// other movie properties, all with public getters and private setters
		public BitmapSource Thumbnail
		{
			get
			{
				if (_thumbnail == null)
				{
					byte[] image = _thumbnailCache.GetThumbnail(_thumbnailId).Image;
					// Convert to BitmapImage for binding purposes
					var bitmapImage = new BitmapImage();
					bitmapImage.BeginInit();
					bitmapImage.StreamSource = new MemoryStream(image);
					bitmapImage.CreateOptions = BitmapCreateOptions.None;
					bitmapImage.CacheOption = BitmapCacheOption.Default;
					bitmapImage.EndInit();
					_thumbnail = bitmapImage;
				}
				return _thumbnail;
			}
		}
		BitmapSource _thumbnail;
	}
