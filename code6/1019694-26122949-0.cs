    public static bool GetFileFromURL(string url, string filename)
    {
        try
        {
            var req = WebRequest.Create(url);
            using (Stream output = File.OpenWrite(filename))
            using (WebResponse res = req.GetResponse())
            using (Stream s = res.GetResponseStream())
                s.CopyTo(output);
            return true;
        }
        catch
        {
            return false;
        }
    }
