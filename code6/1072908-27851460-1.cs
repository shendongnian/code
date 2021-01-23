    private async Task DownloadFileAsync(string fileName)
    {
      // Use HttpClient or whatever to download the file contents.
      var fileContents = await DownloadFileContentsAsync(fileName).ConfigureAwait(false);
    
      // Note that because of the ConfigureAwait(false), we are not on the original context here.
      // Instead, we're running on the thread pool.
    
      // Write the file contents out to a disk file.
      await WriteToDiskAsync(fileName, fileContents).ConfigureAwait(false);
    
      // The second call to ConfigureAwait(false) is not *required*, but it is Good Practice.
    }
    
    // WinForms example (it works exactly the same for WPF).
    private async void DownloadFileButton_Click(object sender, EventArgs e)
    {
      // Since we asynchronously wait, the UI thread is not blocked by the file download.
      await DownloadFileAsync(fileNameTextBox.Text);
    
      // Since we resume on the UI context, we can directly access UI elements.
      resultTextBox.Text = "File downloaded!";
    }
