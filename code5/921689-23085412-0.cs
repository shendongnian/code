        [HttpGet]
        public HttpResponseMessage DownloadData(string serverUrlAddress, string path)
        {
            if (string.IsNullOrWhiteSpace(serverUrlAddress) || string.IsNullOrWhiteSpace(path))
                return null;
        // Create a new WebClient instance
        using (WebClient client = new WebClient())
        {
            // Concatenate the domain with the Web resource filename.
            string url = string.Concat(serverUrlAddress, "/", path);
            if (url.StartsWith("http://") == false)
                url = "http://" + url;
            byte[] data = client.DownloadData(url);
            return new HttpResponseMessage() { Content = new StreamContent(data) };
        }
    } 
