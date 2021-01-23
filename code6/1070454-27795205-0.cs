    string JSONData;
    // Note the async keyword in the method declaration.
    private async void GetWeatherButton_Click(object sender, EventArgs e)
    {
        WebClientToDownload Cls = new WebClientToDownload();
        // Notice the await keyword here which pauses the execution of this method until the data is returned.
        JSONData = await Cls.DownloadFile(GetWeatherText.Text);
        JSONOutput.Text = JSONData;
    } 
