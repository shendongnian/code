    public void getFileFromURL(string url, string filename)
    {
	    using (var webClient = new WebClient())
        {
            File.WriteAllBytes(filename,webClient.DownloadData(url));
        }
    }
