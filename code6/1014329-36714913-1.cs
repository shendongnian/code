	public class MyImageRenderer : ImageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);
			var newImage = e.NewElement as MyImage;
			if (newImage != null)
			{
				newImage.GetBytes = () =>
				{
					var drawable = this.Control.Drawable;
					var bitmap = Bitmap.CreateBitmap(drawable.IntrinsicWidth, drawable.IntrinsicHeight, Bitmap.Config.Argb8888);
					drawable.Draw(new Canvas(bitmap));
					using (var ms = new MemoryStream())
					{
						bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
						return ms.ToArray();
					}
				};
			}
			var oldImage = e.OldElement as MyImage;
			if (oldImage != null)
			{
				oldImage.GetBytes = null;
			}
		}
	}
