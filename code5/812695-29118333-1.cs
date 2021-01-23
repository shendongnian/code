    public void UploadMultipart(byte[] file, string filename, string contentType, string url)
    {
        var webClient = new WebClient();
        string boundary = "------------------------" + DateTime.Now.Ticks.ToString("x");
        webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + boundary);
        var fileData = webClient.Encoding.GetString(file);
        var package = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"file\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n", boundary, filename, contentType, fileData);
        var nfile = webClient.Encoding.GetBytes(package);
        byte[] resp = webClient.UploadData(url, "POST", nfile);
    }
