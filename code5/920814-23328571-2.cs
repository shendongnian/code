    private async void CaptureAudio()
    {
        try
        {
            Debug.WriteLine("Starting record");
            String fileName = AUDIO_FILE_NAME;
            _recordStorageFile = await KnownFolders.VideosLibrary.CreateFileAsync(fileName, CreationCollisionOption.GenerateUniqueName);
            Debug.WriteLine("Create record file successfully");
            MediaEncodingProfile recordProfile = MediaEncodingProfile.CreateM4a(AudioEncodingQuality.Auto);
            await _mediaCaptureManager.StartRecordToStorageFileAsync(recordProfile, this._recordStorageFile);
            Debug.WriteLine("Start Record successful");
        }
        catch(Exception e)
        {
            Debug.WriteLine("Failed to capture audio");
        }
    }
