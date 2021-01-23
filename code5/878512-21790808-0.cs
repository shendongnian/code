    using (WebClient webClient = new WebClient())
    {
        webClient.DownloadFile(remoteFileName, localFilename);
    }
    if(File.Exists(localFilename))
        MessageBox.Show("File Downloaded");
