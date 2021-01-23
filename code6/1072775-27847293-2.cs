    private byte[] GetImage(string url)
    {
        var request = (HttpWebRequest)WebRequest.Create(url);
        var response = (HttpWebResponse)request.GetResponse();
        using (Stream dataStream = response.GetResponseStream())
        {
            if (dataStream == null)
                return null;
            using (var sr = new BinaryReader(dataStream))
            {
                byte[] bytes = sr.ReadBytes(100000);
                return bytes;
            }
        }
        return null;
    }
