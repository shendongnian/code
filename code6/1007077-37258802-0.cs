	try
	{
		// Request access to the microphone only, to limit the number of capabilities we need
		// to request in the package manifest.
		MediaCaptureInitializationSettings settings = new MediaCaptureInitializationSettings();
		settings.StreamingCaptureMode = StreamingCaptureMode.Audio;
		settings.MediaCategory = MediaCategory.Speech;
		MediaCapture capture = new MediaCapture();
		await capture.InitializeAsync(settings);
	}
	catch (TypeLoadException)
	{
		// On SKUs without media player (eg, the N SKUs), we may not have access to the Windows.Media.Capture
		// namespace unless the media player pack is installed. Handle this gracefully.
		var messageDialog = new Windows.UI.Popups.MessageDialog("Media player components are unavailable.");
		await messageDialog.ShowAsync();
		return false;
	}
