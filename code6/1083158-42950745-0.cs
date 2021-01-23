    public async Task<string> TakePicture()
    {
		if (await AuthorizeCameraUse())
		{
			var imagePicker = new UIImagePickerController { SourceType = UIImagePickerControllerSourceType.Camera };
			TaskCompletionSource<string> FinishedCamera = new TaskCompletionSource<string>();
			// When user has taken picture
			imagePicker.FinishedPickingMedia += (sender, e) => {
				// Save the file
				var filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "tmp.png");
				var image = (UIImage)e.Info.ObjectForKey(new NSString("UIImagePickerControllerOriginalImage"));
				image.AsPNG().Save(filepath, false);
				
				// Close the window
				UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
				
				// Stop awaiting
				FinishedCamera.SetResult(filepath);
			};
			// When user clicks cancel 
			imagePicker.Canceled += (sender, e) =>
			{
				UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
				FinishedCamera.TrySetCanceled();
			};
			// Show the camera-capture window
			UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(imagePicker, true, null);
			// Now await for the task to complete or be cancelled
			try
			{
   			    // Return the path we've saved the image in
				return await FinishedCamera.Task;
			}
			catch (TaskCanceledException)
			{
				// handle if the user clicks cancel
			}
		}
		return null;
	}
