    public static string GetAvatar()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.mxit.com/user/public/avatar/vini.katyal");
            
        WebResponse response = request.GetResponse();
        Stream responseStream = response.GetResponseStream();
        MemoryStream ms = new MemoryStream();
        responseStream.CopyTo(ms);
        byte[] buffer = ms.ToArray();
        string result = Convert.ToBase64String(buffer);
        response.Close();
        responseStream.Close();
        return result;
    }
