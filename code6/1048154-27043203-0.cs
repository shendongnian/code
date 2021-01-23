    string rawData;
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    request.ContentLength = bytes.Length;
    using (Stream requestStream = request.GetRequestStream())
    {
        requestStream.Write(bytes, 0, bytes.Length);
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                rawData = sr.ReadToEnd();
            }
        }
    }
