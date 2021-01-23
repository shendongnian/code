        using (ColorFrame frame = reference.ColorFrameReference.AcquireFrame())
        {
            if (frame != null)
            {
                //image.Source = ToBitmap(frame);
                ThreadPool.QueueUserWorkItem(writeColorImage, frame);
            }
        }
