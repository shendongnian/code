            var processingLock = new object();
            if (!isProcessingMotion)
            {
                lock (processingLock)
                {
                    isProcessingMotion = true;
                    // Do stuff..
                    isProcessingMotion = false;
                }
            }
 
