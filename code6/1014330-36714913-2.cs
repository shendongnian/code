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
					return this.Control.Image.AsPNG().ToArray();
				};
			}
			var oldImage = e.OldElement as MyImage;
			if (oldImage != null)
			{
				oldImage.GetBytes = null;
			}
		}
	}
