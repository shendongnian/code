    protected override async void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        if (_mediaCapture != null)
        {
            await _mediaCapture.StopPreviewAsync();
            _mediaCapture.Dispose();
           _mediaCapture = null;
        }
        HardwareButtons.CameraPressed -= HardwareButtonsOnCameraPressed;
        HardwareButtons.CameraHalfPressed -= HardwareButtonsOnCameraHalfPressed;
        DisplayInformation.GetForCurrentView().OrientationChanged -= OnOrientationChanged;
    }
