    public void Download(string url, string localPath)
    {
        HttpWebRequest request = HttpWebRequest.Create(url);
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream stream = response.GetResponseStream();
        FileStream fs = new FileStream(localPath, FileMode.Create);
        int count;
        byte[] buffer = new byte[8096];
        while ((count = stream.Read(buffer, 0, 8096)) > 0)
            fs.Write(buffer, 0, count);
        fs.Dispose();
        response.Close();
    }
