    public static async Task CapturePhoto()
            {
                CameraCaptureUI dialog = new CameraCaptureUI();
                Size aspectRatio = new Size(16, 9);  // 1
                dialog.PhotoSettings.CroppedAspectRatio = aspectRatio; // 2
                dialog.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable; // 3
                dialog.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg; // 4
                dialog.PhotoSettings.AllowCropping = true; //5
    
                StorageFile file = await dialog.CaptureFileAsync(CameraCaptureUIMode.Photo); // Your new file
            }
