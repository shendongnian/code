    private Size GetDisplayedImageSize(PictureBox pictureBox)
	{
		Size containerSize = pictureBox.ClientSize;
		float containerAspectRatio = (float)containerSize.Height / (float)containerSize.Width;
		Size originalImageSize = pictureBox.Image.Size;
		float imageAspectRatio = (float)originalImageSize.Height / (float)originalImageSize.Width;
		Size result = new Size();
		if (containerAspectRatio > imageAspectRatio)
		{
			result.Width = containerSize.Width;
			result.Height = (int)(imageAspectRatio * (float)containerSize.Width);
		}
		else
		{
			result.Height = containerSize.Height;
			result.Width = (int)((1.0f / imageAspectRatio) * (float)containerSize.Height);
		}
		return result;
	}
