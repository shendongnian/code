	public static async Task<bool> AuthorizeCameraUse()
	{
		var authorizationStatus = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video);
		if (authorizationStatus != AVAuthorizationStatus.Authorized)
		{
			return await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVMediaType.Video);
		}
		else
			return true;
	}
	
