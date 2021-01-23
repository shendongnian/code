    CancellationTokenSource _cancelTokenSource;
    async void downloadButton_Click(object sender, EventArgs e)
    {
        // User clicked the button to start download
        _cancelTokenSource = new CancellationTokenSource();
        try
        {
            // For example, update the UI button state so user can't start a
            // new download operation until this one is done, but they can cancel
            // this one.
            downloadButton.Enabled = false;
            cancelButton.Enabled = true;
            // I assume you know where to get the other method arguments, i.e.
            // from "LocalDirectory" on; your incomplete code example didn't
            // provide that detail. :(
            await DownloadFTPAsync(_cancelTokenSource.Token,
                LocalDirectory, RemoteFile, Login, Password);
        }
        catch (OperationCanceledException)
        {
            MessageBox.Show("Download was cancelled by user.");
        }
        catch (Exception ex)
        {
            // Some other error occurred
            MessageBox.Show(ex.ToString())      
        }
        finally
        {
            downloadButton.Enabled = true;
            cancelButton.Enabled = false;
            _cancelTokenSource = null;
        }
    }
