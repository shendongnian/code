        public WritableBitmap GetImage(SynchronizationContext uiThread))
        {
            WriteableBitmap bitmap = null;
            var waitHandle = new object();
            lock (waitHandle)
            {
                uiThread.Post(_ => 
                {
                    lock (waitHandle)
                    {
                       bitmap = new WriteableBitmap(width, height);
                       System.Buffer.BlockCopy(pixelData, 0, bitmap.Pixels, 0, pixelData.Length);
                       bitmap.SaveJpeg(stream, width, height, 0, 100);
                       Monitor.Pulse(waitHandle);
                    }
                }, null);
                Monitor.Wait(waitHandle);
            }
            return bitmap;
       }
