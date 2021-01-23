	private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
	{
		if(videoPlayerDefault.Position ==TimeSpan.Zero)
		{
			videoPlayerDefault.Position = TimeSpan.FromMilliseconds(1);
		}
		else
		{
			videoPlayerDefault.Position = TimeSpan.Zero;
		}
	}
