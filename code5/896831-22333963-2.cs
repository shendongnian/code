    var webClient = new WebClient();
    webClient.DownloadDataCompleted += (s, e) => {
        var text = e.Result; // get the downloaded text
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        string localFilename = "downloaded.mp3";
        string localPath = Path.Combine (documentsPath, localFilename);
        File.WriteAllText (localpath, text); // writes to local storage   
    };
    var url = new Uri("http://url.to.some/file.mp3"); // give this an actual URI to an MP3
    webClient.DownloadDataAsync(url);
