    private void FtpUploading_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
             // Existing code inside the method
        }
        finally
        {
            waitForUpload.Set();
        }
    }
