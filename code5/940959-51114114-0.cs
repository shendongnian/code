    if (progress.TotalBytesToReceive < 0 && progress.BytesReceived == 0)
    {
    	progressPercentage = progress.TotalBytesToSend < 0 ? 0 : progress.TotalBytesToSend == 0 ? 50 : (int)((50 * progress.BytesSent) / progress.TotalBytesToSend);
    }
    else
    {
    	progressPercentage = progress.TotalBytesToSend < 0 ? 50 : progress.TotalBytesToReceive == 0 ? 100 : (int)((50 * progress.BytesReceived) / progress.TotalBytesToReceive + 50);
    }
