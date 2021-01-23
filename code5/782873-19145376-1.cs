    bool isProcessing;
    public void bwScanning()
    {
        if (isProcessing) return;
        isProcessing = true;
        try {
            // the whole code of scanning goes here.
        }
        finally { 
            // in case your processing code throws an exception this ensures you are resetting the flag
            isProcessing = false;
        }
    }
