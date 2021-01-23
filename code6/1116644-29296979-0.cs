    private bool IsWriting = false;
    public void DownloadVersionContents(long fileID, string fileName)
    {
        if (!IsWriting)
        {
            IsWriting = true;
            // Perform the delete and download
            IsWriting = false;
        }
    }
