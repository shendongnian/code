    private readonly object SyncRoot = new object();
    
    private void PHOTO_Show()
    {
        if (!_inProgress)
        {
            // race for a lock
            lock (SyncRoot)
            {
                // check button state
                if (!_repeteTimer.Enabled)
                {
                    // button was released
                    return;
                }
                // else
                try
                {
                    _inProgress = true;
                    MakeImageTreatments();
                }
                finally 
                {
                    _inProgress = false;
                }
            }
        }
    }
