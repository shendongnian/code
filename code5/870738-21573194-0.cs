    private RgbStream(VideoCaptureDevice video)
    {
        videoSource = video;
        currentImage = null;
        updaterLock = new object();
    
        if (videoSource == null)
            return;
    
        //Start the sensor and wait for it to be ready
        videoSource.Start();
        while (!videoSource.IsRunning) { }
    
        //Event for when a frame from the video is ready
        videoSource.NewFrame += (s, e) =>
        {
            if (System.Threading.Monitor.TryEnter(updaterLock, 20))
            {
                Bitmap old = currentImage;
    
                currentImage = (Bitmap)e.Frame.Clone();
                currentImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
    
                if (currentImage != null)
                {
                    if (ImageUpdated != null)
                    {
                        SynchronizationContext context = SynchronizationContext.Current ?? new SynchronizationContext();
                        context.Send(s =>
                        {
                            ImageUpdated(this, EventArgs.Empty);
    
                        }, null);
                    }
    
                    if (old != null)
                    {
                        old.Dispose();
                        old = null;
                    }
                }
                else
                    currentImage = old;
    
                System.Threading.Monitor.Exit(updaterLock);
            }
        };
    }
