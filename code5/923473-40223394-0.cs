    private void uploadButton_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog();
        var dialogResult = openFileDialog.ShowDialog();
        if (dialogResult != DialogResult.OK) return;
        Upload(openFileDialog.FileName);
    } 
    private void Upload(string fileName)
    {
        var client = new WebClient();
        client.UploadFileCompleted += new UploadFileCompletedEventHandler(Completed);
        client.UploadProgressChanged += new UploadProgressChangedEventHandler(ProgressChanged);
        var uri = new Uri("http://www.yoursite.com/UploadFile/");
        try
        {
            client.Headers.Add("fileName", System.IO.Path.GetFileName(fileName));
            var data = System.IO.File.ReadAllBytes(fileName);
            client.UploadDataAsync(uri, data);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    
    private void Completed(object sender, UploadFileCompletedEventArgs e)
    {
        MessageBox.Show(e.Error?.Message ?? "Uploaded Successfully!");
    }
    
    private void ProgressChanged(object sender, UploadProgressChangedEventArgs e)
    {
        progressBar.Value = e.ProgressPercentage;
    }
