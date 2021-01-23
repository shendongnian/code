    protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var ui = new CameraCaptureUI();
            ui.PhotoSettings.CroppedAspectRatio = new Size(4, 3);
            var file = await ui.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (file != null)
            {
                var bitmap = new BitmapImage();
                bitmap.SetSource(await file.OpenAsync(FileAccessMode.Read));
                Photo.Source = bitmap;
            }
        }
