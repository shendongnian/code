    public async void Capture()
    {
       await seq.StartCaptureAsync();
       // Set the stream position to the beginning.
       captureStream1.Seek(0, SeekOrigin.Begin);
       MediaLibrary library = new MediaLibrary();
       Picture picture1 = library.SavePictureToCameraRoll("image1", captureStream1);
    }
