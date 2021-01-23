    private async void InitializeAudioRecording()
    {
        _mediaCaptureManager = new MediaCapture();
        var settings = new MediaCaptureInitializationSettings();
        settings.StreamingCaptureMode = StreamingCaptureMode.Audio;
        settings.MediaCategory = MediaCategory.Other;
        settings.AudioProcessing = (_rawAudioSupported && _userRequestedRaw) ? AudioProcessing.Raw : AudioProcessing.Default;
        await _mediaCaptureManager.InitializeAsync(settings);
        Debug.WriteLine("Device initialised successfully");
        _mediaCaptureManager.RecordLimitationExceeded += new RecordLimitationExceededEventHandler(RecordLimitationExceeded);
        _mediaCaptureManager.Failed += new MediaCaptureFailedEventHandler(Failed);
    }
