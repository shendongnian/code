    private async void Button_Click_1(object sender, RoutedEventArgs e)
    {
        ...
        await TranscodeFileAsync(source, destination);
    }
    async Task TranscodeFileAsync(StorageFile srcFile, StorageFile destFile)
    {
        MediaEncodingProfile profile =
            MediaEncodingProfile.CreateWmv(VideoEncodingQuality.HD1080p);
        MediaTranscoder transcoder = new MediaTranscoder();
        PrepareTranscodeResult prepareOp = await
            transcoder.PrepareFileTranscodeAsync(srcFile, destFile, profile);
        if (prepareOp.CanTranscode)
        {
            var progress = new Progress<double>(percent => { pg1.Value = percent; });
            var result = await prepareOp.TranscodeAsync().AsTask(progress);
            // Display result.
        }
        else
        {
            ...
        }
    }
