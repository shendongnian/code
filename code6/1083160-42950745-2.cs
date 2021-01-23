	private TaskCompletionSource<bool> _tcs_NativeCamera;
	
	public async Task<string> TakePicture()
	{
		_tcs_NativeCamera = new TaskCompletionSource<bool>();
		// Launch the camera activity
		var intent = new Intent(MediaStore.ActionImageCapture);
		intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(cameraCaptureFilePath));
		NextCaptureType = stype;
		StartActivityForResult(intent, SCAN_NATIVE_CAMERA_CAPTURE_ASYNC);
		// Wait here for the activity return (through OnActivityResult)
		var Result = await _tcs_NativeCamera.Task;
		
		// Return the camera capture file path
		return Result != Result.Canceled ? cameraCaptureFilePath : null;
	}
	
	protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
	{
		base.OnActivityResult(requestCode, resultCode, data);
		switch (requestCode)
		{
			case SCAN_NATIVE_CAMERA_CAPTURE_ASYNC:
				_tcs_NativeCamera.SetResult(resultCode);
				break;
		}
	}
