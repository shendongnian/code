	private async void DisplayInformation_OrientationChanged(DisplayInformation sender, object args)
	{
		_displayOrientation = sender.CurrentOrientation;
		if (_isPreviewing)
		{
			await SetPreviewRotationAsync();
		}
	}
	private async Task SetPreviewRotationAsync()
	{
		// Calculate which way and how far to rotate the preview
		int rotationDegrees = ConvertDisplayOrientationToDegrees(_displayOrientation);
		// Add rotation metadata to the preview stream to make sure the aspect ratio / dimensions match when rendering and getting preview frames
		var props = _mediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.VideoPreview);
		props.Properties.Add(RotationKey, rotationDegrees);
		await _mediaCapture.SetEncodingPropertiesAsync(MediaStreamType.VideoPreview, props, null);
	}
	private static int ConvertDisplayOrientationToDegrees(DisplayOrientations orientation)
	{
		switch (orientation)
		{
			case DisplayOrientations.Portrait:
				return 90;
			case DisplayOrientations.LandscapeFlipped:
				return 180;
			case DisplayOrientations.PortraitFlipped:
				return 270;
			case DisplayOrientations.Landscape:
			default:
				return 0;
		}
	}
