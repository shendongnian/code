    async Task ShowPreview()
    {
        try
        {
            await _mediaCapture.InitializeAsync();
            captureElement.Source = _mediaCapture;
            await _mediaCapture.StartPreviewAsync();
        }
        catch (Exception)
        {
            // exception handling ...
            throw;
        }
    }
