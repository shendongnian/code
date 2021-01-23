    resumableUploadTest = youTubeService.Videos.Insert(video, "snippet,status,contentDetails", fileStream, "video/*");
    if (resume)
    {
    	resumableUploadTest.UploadUri = Settings.Default.UploadUri;
    	resumableUploadTest.BytesServerReceived = Settings.Default.BytesServerReceived;					
    }												
    resumableUploadTest.ChunkSize = ResumableUpload<Video>.MinimumChunkSize;
    resumableUploadTest.ProgressChanged += resumableUpload_ProgressChanged;
    resumableUploadTest.UploadAsync();
