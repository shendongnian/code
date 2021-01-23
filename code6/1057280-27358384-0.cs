        Parallel.ForEach(this.urlArray, singleUrl => {
        var apiResponseBlob = new System.Net.WebClient ().DownloadString(singleUrl );
        lock(singleUrl.ToString()){
        this.responsesDictionary.Add(singleUrl, apiResponseBlob);
    }
        }
