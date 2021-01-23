    private static System.Drawing.Image GetImg(string url)
    {
        System.Drawing.Image tmpimg = null;
        var httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
        var httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
        Stream stream = httpWebReponse.GetResponseStream();
        tmpimg = System.Drawing.Image.FromStream(stream);
        return tmpimg;
    }
