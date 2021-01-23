	private async Task CameraCapture()
    {
        CameraCaptureUI camUI = new CameraCaptureUI();
        camUI.PhotoSettings.AllowCropping = true;
        camUI.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.MediumXga;
        camUI.PhotoSettings.CroppedAspectRatio = new Size(4, 3);
        Windows.Storage.StorageFile imageFile = await camUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
        if (imageFile != null)
        {
            // Use unique id for image name since name could change
            string filename = student.StudentID + "Photo.jpg";
			// Move photo to Local Storate and overwrite existing file
			
            await imageFile.MoveAsync(ApplicationData.Current.LocalFolder, filename, NameCollisionOption.ReplaceExisting);
			
			// Open file stream of photo
			
			IRandomAccessStream stream = await imageFile.OpenAsync(FileAccessMode.Read);
            BitmapImage bitmapCamera = new BitmapImage();
            bitmapCamera.SetSource(stream);
			
			student.BitmapPhoto = bitmapCamera // BitmapImage
			
			// Save Uri to photo since we can serialize this and re-create BitmapPhoto on startup/deserialization
            student.UriPhoto = new Uri(string.Format("ms-appdata:///local/{0}", filename), UriKind.Absolute);
        }
    }
