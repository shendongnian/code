	query
		.ToArray()
		.ObserveOn(passAddDisplay)
		.Subscribe(images =>
		{
			var favCollection = new Bitmap(96, 64);
        	using(var g = Graphics.FromImage(favCollection))
			{
				foreach (var image in images)
				{
					g.DrawImage(image.bitmap, image.x, image.y, 16, 16);
					image.bitmap.Dispose();
				}
			}
			passAddDisplay.Image = favCollection;
		});
